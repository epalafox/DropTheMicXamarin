using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace DropTheMic.Models.API
{
	public class APICall
	{
		protected static string Route { get; set; }
		public static string Authorization { get; set; }
		protected int statusCode;
		public int StatusCode { get { return statusCode; } }

		protected static Task<HttpResponseMessage> GetAsync(Dictionary<string, string> parameters)
		{
			string method;
			if (parameters.Count > 0)
				method = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
			else
				method = "";
			return APIClient.Instance().GetAsync(Route + method);
		}
		protected static Task<HttpResponseMessage> PostAsync(object parameters)
		{
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(parameters),Encoding.UTF8, "application/json");
			return APIClient.Instance().PostAsync(Route, httpContent);
		}
		protected static Task<HttpResponseMessage> GetAsyncWithAuthorization(Dictionary<string, string> parameters = null)
		{
			string method;
			if (parameters != null && parameters.Count > 0)
				method = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
			else
				method = "";
			return APIClient.AuthorizedInstance().GetAsync(Route + method);
		}
		protected static Task<HttpResponseMessage> PostAsyncWithAuthorization(object parameters)
		{
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
			return APIClient.AuthorizedInstance().PostAsync(Route, httpContent);
		}
	}
}
