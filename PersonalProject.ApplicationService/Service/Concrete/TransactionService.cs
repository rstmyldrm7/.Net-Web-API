using Microsoft.Extensions.Configuration;
using PersonalProject.ApiContract.Dto;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApplicationService.Authorization.Abstract;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Request;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.Domain;
using PersonalProject.Domain.Aggregate;
using PersonalProject.Domain.Aggregate.Repositories;
using PersonalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Service.Concrete
{
    public class TransactionService : ITransactionService
    {
        private readonly IPaymentCommunicator _paymentCommunicator;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IDbContextHandler _dbContextHandler;
        private readonly IIdentityContext _identityContext;
        private readonly string _apiKey;
        private readonly string _eMail;
        private readonly string _lang;
        public TransactionService(IPaymentCommunicator paymentCommunicator, IConfiguration configuration,
            ITransactionRepository transactionRepository, IDbContextHandler dbContextHandler, IIdentityContext identityContext)
        {
            _paymentCommunicator = paymentCommunicator;
            _transactionRepository = transactionRepository;
            _dbContextHandler = dbContextHandler;
            _identityContext = identityContext;
            _apiKey = configuration["TokenSettings:ApiKey"];
            _eMail = configuration["TokenSettings:Email"];
            _lang = configuration["TokenSettings:Lang"];
        }
        public async Task<GetTokenResponse> GetToken()
        {
            var request = new GetTokenRequest()
            {
                ApiKey = _apiKey,
                Email = _eMail,
                Lang = _lang
            };
            var tokenResp = await _paymentCommunicator.GetToken(request);
            return tokenResp;
        }

        public async Task<NonSecurePaymentResponse> SaleCreditCard(SaleCardRequest request)
        {
            var token = await GetToken();

            if (token == null || string.IsNullOrEmpty(token.result.token))
            {
                throw new Exception("Token bilgisi alınamadı.");
            }

            var info = _identityContext.GetInfo(token.result.token);

            var transaction = await CreateTransaction(request.cardNumber);
            var rnd = Guid.NewGuid().ToString();
            var hash = GeneratePaymentHash(info.UserId, rnd);
            var orderProductList = CreateOrderProductList();

            var requestPayment = new NonSecurePaymentRequest()
            {
                memberId = Convert.ToInt64(info.MemberId),
                merchantId = Convert.ToInt64(info.MerchantId),
                cardNumber = request.cardNumber,
                expiryDateMonth = request.expiryDateMonth,
                expiryDateYear = request.expiryDateYear,
                userCode = info.UserId,
                txnType = "AUTH",
                installmentCount = "1",
                currency = "949",
                orderId = "5555555555",
                totalAmount = "1",
                rnd = rnd,
                hash = hash,
                orderProductList = orderProductList
            };

            var response = await MakePayment(requestPayment, token.result.token);
            if (response != null && response.result != null)
            {
                await UpdateTransaction(response.result.responseCode, response.result.responseMessage, transaction);
                return response;
            }

            throw new Exception("Ödeme işleminde hata alındı.");
        }

        private async Task<Transaction> CreateTransaction(string cardNumber)
        {
            var transaction = new Transaction("1", "5555555555", TransactionType.Sale, 1, cardNumber);
            await _transactionRepository.SaveAsync(transaction);
            await _dbContextHandler.SaveChangesAsync();
            return transaction;
        }

        private string GeneratePaymentHash(string userId, string rnd)
        {
            var hashRequest = new PaymentHash()
            {
                HashPassword = _apiKey,
                UserCode = userId,
                Rnd = rnd,
                TxnType = "AUTH",
                TotalAmount = "1",
                CustomerId = "1",
                OrderId = "5555555555",
            };
            return PaymentHash(hashRequest);
        }

        private List<OrderProduct> CreateOrderProductList()
        {
            var orderProduct = new OrderProduct()
            {
                merchantId = 1,
                productId = "0",
                amount = "1",
                productName = "CreditCardSale",
                commissionRate = "0.00"
            };

            var orderProductList = new List<OrderProduct>();
            orderProductList.Add(orderProduct);
            return orderProductList;
        }

        private async Task<NonSecurePaymentResponse> MakePayment(NonSecurePaymentRequest request, string token)
        {
            var response = await _paymentCommunicator.NonSecurePayment(request, token);
            if (response != null && response.result != null)
            {
                return response;
            }
            return null;
        }

        private async Task UpdateTransaction(string responseCode, string responseMessage, Transaction transaction)
        {
            transaction.SetTransactionComplete(responseCode, responseMessage);
            _transactionRepository.Update(transaction);
            await _dbContextHandler.SaveChangesAsync();
        }

        private static string PaymentHash(PaymentHash request)
        {
            var hashString = $"{request.HashPassword}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}";
            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create();
            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding();
            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));
            var hash = System.BitConverter.ToString(bytes).Replace("-", "");
            return hash;
        }

    }
}
