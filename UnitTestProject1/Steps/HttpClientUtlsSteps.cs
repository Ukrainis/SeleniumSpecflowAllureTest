using FluentAssertions;
using TechTalk.SpecFlow;
using UnitTestProject1.Utils;

namespace UnitTestProject1.Steps
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