using System;
using System.Net.Http;
using System.Net.Http.Headers;
namespace DropTheMic.Models.API
{
	public class APIClient
	{
		static HttpClient httpClient;
		static HttpClient httpAuthorizedClient;
		public static string WebToken { get; set; }
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
		public static HttpClient AuthorizedInstance()
		{
			if (WebToken == "")
				throw new Exception("WebToken not set");
			if (httpAuthorizedClient == null)
			{
				httpAuthorizedClient = new HttpClient()
				{
					BaseAddress = new Uri(APIURL),
					Timeout = TimeSpan.FromMinutes(2)
				};
				httpAuthorizedClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			}
			httpAuthorizedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(WebToken);
			return httpAuthorizedClient;
		}
    }
}
