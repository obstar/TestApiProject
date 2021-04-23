using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestApiProject.Api
{
    public class BaseApiCall
    {
        private readonly HttpClient _httpClient;

        public BaseApiCall()
        {
            _httpClient = new HttpClient
                          {
                              Timeout = TimeSpan.FromSeconds(30)
                          };
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _httpClient.GetAsync(endpoint);
        }

        //I could add more methods for put, post, delete..
    }
}
