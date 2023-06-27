using Microsoft.Extensions.Configuration;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Request;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Concrete
{
    public class PaymentCommunicator : IPaymentCommunicator
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;
        public PaymentCommunicator(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = configuration["TokenServiceBaseUrl"];
        }

        public async Task<GetTokenResponse> GetToken(GetTokenRequest request)
        {
            var tokenResponse = new GetTokenResponse();
            using (var userHttpClient = _httpClientFactory.CreateClient("transaction"))
            {
                var timer = new Stopwatch();
                timer.Start();
                var content = JsonContent.Create(request);
                var httpResponseMessage =
                   await userHttpClient.PostAsync(_baseUrl + "/ppg/Securities/authenticationMerchant", content);

                var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();

                timer.Stop();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                tokenResponse = JsonSerializer.Deserialize<GetTokenResponse>(readAsStringAsync, options);
            }
            var json = JsonSerializer.Serialize(tokenResponse);

            return JsonSerializer.Deserialize<GetTokenResponse>(json);
        }
    }
}
