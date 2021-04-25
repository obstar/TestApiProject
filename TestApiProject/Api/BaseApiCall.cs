using System.Threading.Tasks;
using RestSharp;

namespace TestApiProject.Tests.Api
{
    public class BaseApiCall
    {
        protected Task<IRestResponse> GetItAsync(string baseUrl,
                                                 string resources)
        {
            return new RestClient(baseUrl).ExecuteGetAsync(new RestRequest(resources, Method.GET));
        }

        protected Task<IRestResponse> PostItAsync(string baseUrl,
                                                  string jsonBody)
        {
            return new RestClient(baseUrl).ExecutePostAsync(new RestRequest()
                                                                .AddJsonBody(jsonBody));
        }

        //other methods can be added as needed
    }
}