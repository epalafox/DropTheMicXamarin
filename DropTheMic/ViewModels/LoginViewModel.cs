using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DropTheMic.Models;
using DropTheMic.Models.API;

namespace DropTheMic.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		bool isBusy;
		string userName;
		string password;
		public bool IsBusy
		{
			get 
			{ 
				return isBusy; 
			}
			set
			{
				if(isBusy != value)
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
				if(userName != value)
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
				if(password != value)
				{
					password = value;
					OnPropertyChanged();
				}
			}
		}

		public Command LogInCommand
		{
			get
			{
				return new Command(() =>
				{
					IsBusy = true;
					Authorization.Validate(userName, password).ContinueWith((authorization) =>
					{
						IsBusy = false;
						if(authorization.Result.StatusCode == 200)
						{
							APIClient.WebToken = authorization.Result.WebToken;
							MessagingCenter.Send(this, "UserLogged", authorization.Result);
						}
						else if(authorization.Result.StatusCode == 404)
						{
							MessagingCenter.Send(this, "ShowAuthorizationAlert", new MessageModel()
							{
								Title = "User not found",
								Message = "The username and password were not found"
							});
						}
						else if(authorization.Result.StatusCode == 400)
						{
							MessagingCenter.Send(this, "ShowAuthorizationAlert", new MessageModel()
							{
								Title = "User and Password Required",
								Message = "Please type your Username and Password"
							});
						}
						else
						{
							MessagingCenter.Send(this, "ShowAuthorizationAlert", new MessageModel()
							{
								Title = "Unexpected Error",
								Message = "There was an unexpected error, please check your internet connection"
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
		public LoginViewModel()
		{
			
		}
	}
}
