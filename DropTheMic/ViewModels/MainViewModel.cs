using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DropTheMic.Models.API;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DropTheMic.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		bool isBusy;
		bool isPosting;
		bool isRefreshing;
		string newPost;
		ObservableCollection<PostViewModel> posts;
		public ObservableCollection<PostViewModel> Posts 
		{
			get { 
				return posts; 
			} 
			set{ 
				if (posts != value) 
				{ 
					posts = value; 
					OnPropertyChanged();
				}
			} 
		}
		public bool IsBusy { 
			get
			{
				return isBusy;
			} 
			set {
				if(isBusy != value){
					isBusy = value;
					OnPropertyChanged();
				}
			}
		}
		public bool IsPosting
		{
			get
			{
				return isPosting;
			}
			set
			{
				if (isPosting != value)
				{
					isPosting = value;
					OnPropertyChanged();
				}
			}
		}
		public string NewPost{
			get{
				return newPost;
			}
			set{
				if(newPost != value)
				{
					newPost = value;
					OnPropertyChanged();
				}
			}
		}
		public bool IsRefreshing{
			get{
				return isRefreshing;
			}
			set{
				if(isRefreshing != value)
				{
					isRefreshing = value;
					OnPropertyChanged();
				}
			}
		}
		public MainViewModel()
		{
			Posts = new ObservableCollection<PostViewModel>()
			{
				new PostViewModel()
				{
					Comments = 0,
					Date = "02/05/2018",
					Hour = "",
					Id = 0,
					Post = "Loading Posts",
					User = ""
				}
			};

			LoadPosts();
		}
		public Command Post{
			get{
				return new Command(() =>
				{
					PostModel newPostModel = new PostModel()
					{
						Post = NewPost
					};
					IsBusy = true;
					PostModel.Create(newPostModel).ContinueWith((result) => {
						IsBusy = false;
						LoadPosts();
						NewPost = "";
						IsPosting = false;
					});
				});
			}
		}
		public Command CancelPost
		{
			get
			{
				return new Command(() =>
				{
					IsPosting = false;
					NewPost = "";
				});
			}
		}
		public Command RefreshCommand
		{
			get{
				return new Command(() =>
				{
					IsRefreshing = false;
					LoadPosts();
				});
			}
		}
		private void LoadPosts(){
			IsBusy = true;
			PostModel.GetPosts().ContinueWith((postList) =>
			{
				Posts = new ObservableCollection<PostViewModel>(postList.Result.Select(x => new PostViewModel()
				{
					Comments = x.Comments.Count(),
					CommentList = new ObservableCollection<CommentViewModel>(x.Comments.Select(y => new CommentViewModel(){
						Comments = y.Comments.Count(),
						Date = y.Date,
						Hour = y.Hour,
						Id = y.Id,
						User = y.User.UserName,
						Comment = y.Comment
					})),
					Date = x.Date,
					Hour = x.Hour,
					Id = x.Id,
					Post = x.Post,
					User = x.User.UserName
				}).ToList());
				IsBusy = false;
				MessagingCenter.Send(this, "PostsLoaded", Posts);
			});
		}  
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
