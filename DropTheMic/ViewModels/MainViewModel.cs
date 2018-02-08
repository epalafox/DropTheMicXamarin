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
				if(NewPost != value)
				{
					newPost = value;
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
			IsBusy = true;
			PostModel.GetPosts().ContinueWith((result) => 
			{
				Posts = new ObservableCollection<PostViewModel>(result.Result.Select(x => new PostViewModel()
				{
					Comments = x.Comments.Count(),
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
		public Command Post{
			get{
				return new Command(() =>
				{
					IsBusy = true;
					PostModel newPostModel = new PostModel()
					{
						User = new User()
						{
							UserName = Application.Current.Properties["UserName"].ToString(),
							IdUser = int.Parse(Application.Current.Properties["IdUser"].ToString()),
							Gender = 1,
							Birthday = "2018-01-01"
						},
						Post = NewPost
					};
					PostModel.Create(newPostModel).ContinueWith((result) => {
						PostModel.GetPosts().ContinueWith((posts) =>
						{
							Posts = new ObservableCollection<PostViewModel>(posts.Result.Select(x => new PostViewModel()
							{
								Comments = x.Comments.Count(),
								Date = x.Date,
								Hour = x.Hour,
								Id = x.Id,
								Post = x.Post,
								User = x.User.UserName
							}).ToList());
							IsBusy = false;
							IsPosting = false;
							NewPost = "";
							MessagingCenter.Send(this, "PostsLoaded", Posts);
						});
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
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
