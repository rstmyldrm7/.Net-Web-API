using Microsoft.Extensions.Configuration;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Request;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Concrete
{
    public class PaymentCommunicator : IPaymentCommunicator
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseTokenUrl;
        private readonly string _basePaymentUrl;
        public PaymentCommunicator(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _baseTokenUrl = configuration["TokenServiceBaseUrl"];
            _basePaymentUrl = configuration["PaymentServiceBaseUrl"];
        }

        public async Task<GetTokenResponse> GetToken(GetTokenRequest request)
        {
            var tokenResponse = new GetTokenResponse();
            using (var userHttpClient = _httpClientFactory.CreateClient("transaction"))
            {
                var content = JsonContent.Create(request);
                var httpResponseMessage =
                   await userHttpClient.PostAsync(_baseTokenUrl + "/ppg/Securities/authenticationMerchant", content);

                var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();


                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                tokenResponse = JsonSerializer.Deserialize<GetTokenResponse>(readAsStringAsync, options);
            }
            var json = JsonSerializer.Serialize(tokenResponse);

            return JsonSerializer.Deserialize<GetTokenResponse>(json);
        }

        public async Task<NonSecurePaymentResponse> NonSecurePayment(NonSecurePaymentRequest request, string token)
        {
            var response = new NonSecurePaymentResponse();
            using (var userHttpClient = _httpClientFactory.CreateClient("transaction"))
            {
                userHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = JsonContent.Create(request);
                var httpResponseMessage =
                   await userHttpClient.PostAsync(_basePaymentUrl + "/ppg/Payment/NoneSecurePayment", content);

                var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                response = JsonSerializer.Deserialize<NonSecurePaymentResponse>(readAsStringAsync, options);
            }
            var json = JsonSerializer.Serialize(response);

            return JsonSerializer.Deserialize<NonSecurePaymentResponse>(json);
        }
    }
}
