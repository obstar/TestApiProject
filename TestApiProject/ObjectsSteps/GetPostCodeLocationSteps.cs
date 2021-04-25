
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TestApiProject.Tests.Api.Calls;
using TestApiProject.Tests.Api.Models;

namespace TestApiProject.Tests.ObjectsSteps
{
    [Binding]
    [Scope(Tag = "@PostCode")]
    public class GetPostCodeLocationSteps
    {
        private readonly GetPostCodeLocationApiCall _getPostCodeLocationApiCall;
        private IRestResponse _fullResponse;
        private GetPostCodeLocationModel _postCodeLocationBody;

        public GetPostCodeLocationSteps(GetPostCodeLocationApiCall getPostCodeLocationApiCall)
        {
            _getPostCodeLocationApiCall = getPostCodeLocationApiCall;
        }


        [Given(@"I perform get request to endpoint for (.*) country code with (.*) post code")]
        public async Task GivenIPerformGetRequestToEndpointForCountryCodeWithPostCode(string countryCode, 
                                                                                      string postCode)
        {
            _fullResponse = await _getPostCodeLocationApiCall.Get(countryCode, postCode);
        }

        [When(@"I have body from get post code location response")]
        public void WhenIHaveBodyFromGetPostCodeLocationResponse()
        {
            _postCodeLocationBody = JsonConvert.DeserializeObject<GetPostCodeLocationModel>(_fullResponse.Content);
        }

        [Then(@"the request status code is '(.*)'")]
        public void ThenTheRequestStatusCodeIs(string httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, _fullResponse.StatusCode.ToString());
        }
    }
}