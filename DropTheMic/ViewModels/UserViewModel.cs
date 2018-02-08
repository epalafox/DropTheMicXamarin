using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DropTheMic.Models;
using DropTheMic.Models.API;
using Xamarin.Forms;

namespace DropTheMic.ViewModels
{
	public class UserViewModel : INotifyPropertyChanged
	{
		bool isBusy;
		string userName;
		string password;
		DateTime birthDay = DateTime.Now;
		int gender;

		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					OnPropertyChanged();
				}
			}
		}

		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				if (userName != value)
				{
					userName = value;
					OnPropertyChanged();
				}
			}
		}
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				if (password != value)
				{
					password = value;
					OnPropertyChanged();
				}
			}
		}

		public DateTime BirthDay
		{
			get
			{
				return birthDay;
			}
			set
			{
				if(birthDay != value)
				{
					birthDay = value;
					OnPropertyChanged();
				}
			}
		}

		public string Gender
		{
			get
			{
				return GendersModel.FromInt(gender);
			}
			set
			{
				if(gender != GendersModel.FromString(value))
				{
					gender = GendersModel.FromString(value);
					OnPropertyChanged();
				}
			}
		}

		public Command SignUpCommand
		{
			get
			{
				return new Command(() =>
				{
					IsBusy = true;
					User user = new User()
					{
						Birthday = birthDay,
						Gender = gender,
						Password = password,
						UserName = userName
					};
					User.Create(user).ContinueWith((result) =>
					{
						if(result.IsCompleted)
						{
							Authorization.Validate(user.UserName, user.Password).ContinueWith((auth) =>{
								IsBusy = false;
								MessagingCenter.Send(this, "Signed", auth.Result);
							});

						}
						else
						{
							IsBusy = false;
							MessagingCenter.Send(this, "ShowSignUpAlert", new MessageModel()
							{
								Title = "Unexpected Error",
								Message = "There was an unexpected error please check your connection"
							});
						}
					});
				});
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public UserViewModel()
		{
		}
	}
}
