using System;
using System.Net.Http;
using System.Net.Http.Headers;
namespace DropTheMic.Models
{
    public class APIClient
    {
        static HttpClient httpClient;
        const string APIURL = "http://dropthemic.azurewebsites.net/api/";
        private APIClient()
        {
        }
        public static HttpClient Instance()
        {
            if(httpClient == null)
            {
                httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(APIURL),
                    Timeout = TimeSpan.FromMinutes(2)
                };
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return httpClient;
        }
    }
}
