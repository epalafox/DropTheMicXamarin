using System;
namespace DropTheMic.ViewModels
{
	public class PostViewModel
	{
		int id;
		string post;
		string date;
		string hour;
		int comments;
		string user;
		public int Id
		{
			get{
				return id;
			}
			set{
				if(id != value)
				{
					id = value;
				}
			}
		}
		public string Post
		{
			get{
				return post;
			}
			set{
				if(post != value)
				{
					post = value;
				}
			}
		}
		public string Date
		{
			get{
				return date;
			}
			set{
				if(date != value)
				{
					date = value;
				}
			}
		}
		public string Hour
		{
			get{
				return hour;
			}
			set{
				if(hour != value)
				{
					hour = value;
				}
			}
		}
		public int Comments
		{
			get{
				return comments;
			}
			set{
				if(comments != value)
				{
					comments = value;
				}
			}
		}
		public string User{
			get{
				return user;
			}
			set{
				if(user != value)
				{
					user = value;
				}
			}
		}
		public PostViewModel()
		{
		}
	}
}
