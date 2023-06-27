using Microsoft.Extensions.Configuration;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Request;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using PersonalProject.ApplicationService.Service.Abstract;
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
        private readonly string _apiKey;
        private readonly string _eMail;
        private readonly string _lang;
        public TransactionService(IPaymentCommunicator paymentCommunicator, IConfiguration configuration)
        {
            _paymentCommunicator= paymentCommunicator;
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
    }
}
