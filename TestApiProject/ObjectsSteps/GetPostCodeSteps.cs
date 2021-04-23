using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestApiProject.Api.Calls;

namespace TestApiProject.ObjectsSteps
{
    [Binding]
    [Scope(Tag = "@PostCode")]
    public class GetPostCodeSteps
    {
        //  private readonly GetPostCodeActions _getPostCodeActions;
        private readonly GetPostCodeApiCall _getPostCodeApiCall;
        private HttpResponseMessage _response;

        public GetPostCodeSteps(//GetPostCodetActions getPostCodetActions,
                    GetPostCodeApiCall getPostCodeApiCall)
        {
          //  _getPostCodeActions = getPostCodeActions;
            _getPostCodeApiCall = getPostCodeApiCall;
        }

        [Given(@"I perform get request to endpoint for '(.*)' country code with '(.*)' post code")]
        public async void GivenIPerformGetRequestToEndpointForCountryCodeWithPostCode(string countryCode, string postCode)
        {
            _response = await _getPostCodeApiCall.GetItAsync(countryCode, postCode);
        }

        [Then(@"the post code get request is '(.*)'")]
        public void ThenThePostCodeGetRequestIs(string httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, _response.StatusCode.ToString());
        }
    }
}