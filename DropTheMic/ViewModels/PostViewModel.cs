using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DropTheMic.Models.API;
using Xamarin.Forms;

namespace DropTheMic.ViewModels
{
	public class PostViewModel : INotifyPropertyChanged
	{
		int id;
		string post;
		string date;
		string hour;
		int comments;
		string user;
		ObservableCollection<CommentViewModel> commentList;
		bool isBusy;
		bool isCommenting;
		string newComment;
		public int Id
		{
			get{
				return id;
			}
			set{
				if(id != value)
				{
					id = value;
					OnPropertyChanged();
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
					OnPropertyChanged();
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
					OnPropertyChanged();
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
					OnPropertyChanged();
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
					OnPropertyChanged();
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
					OnPropertyChanged();
				}
			}
		}
		public ObservableCollection<CommentViewModel> CommentList{
			get{
				return commentList;
			}
			set{
				if(commentList != value){
					commentList = value;
					OnPropertyChanged();
				}
			}
		}
		public bool IsCommenting{
			get{
				return isCommenting;
			}
			set{
				if(isCommenting != value){
					isCommenting = value;
					OnPropertyChanged();
				}
			}
		}
		public string NewComment{
			get{
				return newComment;
			}
			set{
				if(newComment != value){
					newComment = value;
					OnPropertyChanged();
				}
			}
		}
		public bool IsBusy{
			get{
				return isBusy;
			}
			set{
				if(isBusy != value){
					isBusy = value;
					OnPropertyChanged();
				}
			}
		}
		public Command Comment
		{
			get
			{
				return new Command(() =>
				{
					CommentModel newCommentModel = new CommentModel()
					{
						Comment = NewComment
					};
					IsBusy = true;
					CommentModel.Create(Id, newCommentModel).ContinueWith((result) => {
						IsBusy = false;
						NewComment = "";
						IsCommenting = false;
					});
				});
			}
		}
		public Command CancelComment
		{
			get
			{
				return new Command(() =>
				{
					IsCommenting = false;
					NewComment = "";
				});
			}
		}
		public PostViewModel()
		{
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
