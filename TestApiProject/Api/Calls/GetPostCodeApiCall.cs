using System.Net.Http;
using System.Threading.Tasks;
using TestApiProject.Config;

namespace TestApiProject.Api.Calls
{
    public class GetPostCodeApiCall : BaseApiCall
    {
        public Task<HttpResponseMessage> GetItAsync(string countryCode,string postCode)
        {
            return GetAsync($"{EndPoints.PostCode.GetUrl()}/{countryCode}/{postCode}");
        }
    }
}