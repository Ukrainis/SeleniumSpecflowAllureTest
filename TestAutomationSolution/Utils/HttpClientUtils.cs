using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAutomationSolution.Utils
{
    public class HttpClientUtils
    {
        private readonly HttpClient client;

        public HttpClientUtils()
        {
            client = new HttpClient(){BaseAddress = new Uri(
                System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"]) };
        }

        public Task<HttpResponseMessage> MakeGetRequestToEndpoint(string endpoint)
        {
            var response = client.GetAsync(endpoint);
            return response;
        }
    }
}