using System.Threading.Tasks;
using RestSharp;
using TestApiProject.Tests.Config;

namespace TestApiProject.Tests.Api.Calls
{
    public class GetPostCodeLocationApiCall : BaseApiCall
    {
        public Task<IRestResponse> Get(string countryCode, string postCode)
        {
            return base.Get(EndPoints.PostCode.GetUrl(),$"{countryCode}/{postCode}");
        }
    }
}