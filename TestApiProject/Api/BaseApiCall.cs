using System.Threading.Tasks;
using RestSharp;

namespace TestApiProject.Tests.Api
{
    public class BaseApiCall
    {
        protected Task<IRestResponse> Get(string baseUrl, string resources) 
        {
            return new RestClient(baseUrl).ExecuteGetAsync(new RestRequest(resources, Method.GET));
        }
        
        //other methods can be added as needed
    }
}
