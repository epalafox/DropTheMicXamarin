using System;
using System.Collections.ObjectModel;

namespace DropTheMic.ViewModels
{
	public class CommentViewModel
	{
		int id;
		string comment;
		string date;
		string hour;
		int comments;
		string user;
		ObservableCollection<CommentViewModel> commentList;
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
		public string Comment
		{
			get{
				return comment;
			}
			set{
				if(comment != value)
				{
					comment = value;
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
		public ObservableCollection<CommentViewModel> CommentList
		{
			get
			{
				return commentList;
			}
			set
			{
				if (commentList != value)
				{
					commentList = value;
				}
			}
		}
		public CommentViewModel()
		{
		}
	}
}
