using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestApiProject.Api.Calls;

namespace TestApiProject.ObjectsSteps
{
    [Binding]
    [Scope(Tag = "@PostCode")]
    public class GetPostCodeLocationSteps
    {
        private readonly GetPostCodeLocationApiCall _getPostCodeLocationApiCall;
        private HttpResponseMessage _response;

        public GetPostCodeLocationSteps(GetPostCodeLocationApiCall getPostCodeLocationApiCall)
        {
            _getPostCodeLocationApiCall = getPostCodeLocationApiCall;
        }

        [Given(@"I perform get request to endpoint for '(.*)' country code with '(.*)' post code")]
        public async void GivenIPerformGetRequestToEndpointForCountryCodeWithPostCode(string countryCode, string postCode)
        {
            _response = await _getPostCodeLocationApiCall.GetItAsync(countryCode, postCode);
        }

        [Then(@"the post code get request is '(.*)'")]
        public void ThenThePostCodeGetRequestIs(string httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, _response.StatusCode.ToString());
        }
    }
}