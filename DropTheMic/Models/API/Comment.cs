using System;
using System.Collections.Generic;

namespace DropTheMic.Models.API
{
	public class CommentModel
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }
		public string Hour { get; set; }
		public User User { get; set; }
		public List<CommentModel> Comments { get; set; }
		public CommentModel()
		{
		}
	}
}
