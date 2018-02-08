using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropTheMic.Models.API
{
	public class PostModel : APICall
	{
		public int Id { get; set; }
		public string Post { get; set; }
		public string Date { get; set; }
		public string Hour { get; set; }
		public User User { get; set; }
		public List<CommentModel> Comments {get;set;}

		public static Task<List<PostModel>> GetPosts()
		{
			Route = "Post";
			return GetAsyncWithAuthorization().ContinueWith((response) =>
			{
				return JsonConvert.DeserializeObject<List<PostModel>>(response.Result.Content.ReadAsStringAsync().Result);
			});
		}
		public static Task Create(PostModel newPost)
		{
			Route = "Post";
			return PostAsyncWithAuthorization(newPost);
		}
		public PostModel()
		{
		}
	}
}
