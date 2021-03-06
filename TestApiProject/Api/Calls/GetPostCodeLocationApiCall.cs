using System.Threading.Tasks;
using RestSharp;
using TestApiProject.Tests.Config;

namespace TestApiProject.Tests.Api.Calls
{
    public class GetPostCodeLocationApiCall : BaseApiCall
    {
        public Task<IRestResponse> GetAsync(string countryCode,
                                            string postCode)
        {
            return GetItAsync(EndPoints.PostCode.GetUrl(), $"{countryCode}/{postCode}");
        }

        public Task<IRestResponse> WrongPostAsync(string countryCode,
                                             string postCode)
        {
            return PostItAsync(EndPoints.PostCode.GetUrl(), $"{countryCode}/{postCode}");
        }
    }
}