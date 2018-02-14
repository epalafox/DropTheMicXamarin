using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DropTheMic.Models.API
{
	public class CommentModel :APICall
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }
		public string Hour { get; set; }
		public User User { get; set; }
		public List<CommentModel> Comments { get; set; }
		public static Task Create(int idPost, CommentModel newComment)
		{
			Route = "Comment/" + idPost;
			return PostAsyncWithAuthorization(newComment);
		}
		public CommentModel()
		{
		}
	}
}
