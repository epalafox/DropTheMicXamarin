using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DropTheMic.Models
{
    public class Authorization
    {
        public string UserName { get; set; }
        public string Password { get; set; }
		public string WebToken { get; set; }
		public int IdUser { get; set; }
		public int result { get; set; }


        const string route = "Authorization";

        private Authorization()
        {
        }
		public static Task<Authorization> Validate(string userName, string password)
        {
            return APIClient.Instance().GetAsync(route).ContinueWith(((response) =>{
				Authorization authorization = new Authorization()
				{
					UserName = userName,
					Password = password,
					result = (int)response.Result.StatusCode
				};
				if(authorization.result == (int)System.Net.HttpStatusCode.OK)
				{
					authorization.WebToken = JsonConvert.DeserializeObject<Authorization>(response.Result.Content.ToString()).WebToken;
					authorization.IdUser = JsonConvert.DeserializeObject<Authorization>(response.Result.Content.ToString()).IdUser;

				}

				return authorization;
            }));
        }
    }
}
