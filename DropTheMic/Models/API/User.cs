using System;
using System.Net;
using System.Threading.Tasks;

namespace DropTheMic.Models.API
{
	public class User : APICall
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Birthday { get; set; }
		public int Gender { get; set; }
		public int IdUser { get; set; }

		public static Task<User> Create(User user)
		{
			Route = "Users";
			return PostAsync(user).ContinueWith((response) =>
			{
				user.statusCode = (int)response.Result.StatusCode;
				return user;
			});
		}

		public User()
		{
		}
	}
}
