
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TestApiProject.Tests.Api.Calls;
using TestApiProject.Tests.Api.Models;
using TestApiProject.Tests.Config;

namespace TestApiProject.Tests.ObjectsSteps
{
    [Binding]
    [Scope(Tag = "@PostCode")]
    public class GetPostCodeLocationSteps
    {
        private readonly AssertExtension _assertExtension;
        private readonly GetPostCodeLocationApiCall _getPostCodeLocationApiCall;
        private IRestResponse _fullResponse;
        private GetPostCodeLocationModel _postCodeLocationBody;

        public GetPostCodeLocationSteps(AssertExtension assertExtension,GetPostCodeLocationApiCall getPostCodeLocationApiCall)
        {
            _assertExtension = assertExtension;
            _getPostCodeLocationApiCall = getPostCodeLocationApiCall;
        }


        [Given(@"I perform get request to endpoint for (.*) country code with (.*) post code")]
        public async Task GivenIPerformGetRequestToEndpointForCountryCodeWithPostCode(string countryCode, 
                                                                                      string postCode)
        {
            _fullResponse = await _getPostCodeLocationApiCall.GetAsync(countryCode, postCode);
        }

        [When(@"I have body from get post code location response")]
        public void WhenIHaveBodyFromGetPostCodeLocationResponse()
        {
            _postCodeLocationBody = JsonConvert.DeserializeObject<GetPostCodeLocationModel>(_fullResponse.Content);
        }

        [Then(@"the response status code is '(.*)'")]
        public void ThenTheResponseStatusCodeIs(string httpStatusCode)
        {
            _assertExtension.AreEqual(httpStatusCode, _fullResponse.StatusCode.ToString());
        }

        [Then(@"the response has post code equal to (.*)")]
        public void ThenTheResponseHasPostCodeEqualTo(string postCode)
        {
            _assertExtension.AreEqual(postCode, _postCodeLocationBody.PostCode);
        } 
        
        [Then(@"the response has country equal to (.*)")]
        public void ThenTheResponseHasCountryEqualTo(string countryName)
        {
            _assertExtension.AreEqual(countryName, _postCodeLocationBody.Country);
        }

        [Then(@"the response has country abbreviation equal to (.*)")]
        public void ThenTheResponseHasCountryAbbreviationEqualTo(string countryCode)
        {
            _assertExtension.AreEqual(countryCode, _postCodeLocationBody.CountryAbbreviation);
        }

        [Then(@"the response has places equal to (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenTheResponseHasPlacesEqualToAnd(string placeName, 
                                                       string state, 
                                                       string stateCode, 
                                                       string longitude, 
                                                       string latitude)
        {
            _assertExtension.AreEqual(placeName, _postCodeLocationBody.Places[0].PlaceName);
            _assertExtension.AreEqual(state, _postCodeLocationBody.Places[0].State);
            _assertExtension.AreEqual(stateCode, _postCodeLocationBody.Places[0].StateAbbreviation);
            _assertExtension.AreEqual(longitude, _postCodeLocationBody.Places[0].Longitude);
            _assertExtension.AreEqual(latitude, _postCodeLocationBody.Places[0].Latitude);
        }
    }
}