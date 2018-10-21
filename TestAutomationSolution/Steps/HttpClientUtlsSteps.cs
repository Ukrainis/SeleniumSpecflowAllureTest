using FluentAssertions;
using TechTalk.SpecFlow;
using TestAutomationSolution.Utils;

namespace TestAutomationSolution.Steps
{
    [Binding]
    public class HttpClientUtlsSteps
    {
        private readonly HttpClientUtils httpClientUtils;

        public HttpClientUtlsSteps()
        {
            httpClientUtils = new HttpClientUtils();
        }

        [Given(@"I make Get request to the ""(.*)"" endpoint and getting (.*) as response")]
        public void GivenIMakeGetRequestToTheEndpointAndGettingAsResponse(string endpoint, 
            int statusCodeExpected)
        {
            var result = httpClientUtils.MakeGetRequestToEndpoint(endpoint).Result;

            result.StatusCode.Should().BeEquivalentTo(statusCodeExpected);
        }
    }
}