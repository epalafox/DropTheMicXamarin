using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropTheMic.Models.API
{
	public class Authorization : APICall
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string WebToken { get; set; }
		public int IdUser { get; set; }

		public static Task<Authorization> Validate(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				return Task.Run(() =>
				{
					Authorization authorization = new Authorization()
					{
						UserName = userName,
						Password = password,
						statusCode = 400
					};
					return authorization;
				});
			Route = "Authorization";
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("UserName", userName);
			parameters.Add("Password", password);
			return GetAsync(parameters).ContinueWith(((response) =>
			{
				Authorization authorization = new Authorization()
				{
					UserName = userName,
					Password = password,
					statusCode = (int)response.Result.StatusCode
				};
				if (authorization.StatusCode == (int)System.Net.HttpStatusCode.OK)
				{
					authorization.WebToken = JsonConvert.DeserializeObject<Authorization>(response.Result.Content.ReadAsStringAsync().Result).WebToken;
					authorization.IdUser = JsonConvert.DeserializeObject<Authorization>(response.Result.Content.ReadAsStringAsync().Result).IdUser;

				}

				return authorization;
			}));
		}
	}
}
