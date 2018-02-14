using System;
using System.Collections.Generic;
using DropTheMic.ViewModels;
using DropTheMic.Models;

using Xamarin.Forms;
using DropTheMic.Models.API;

namespace DropTheMic.Views
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage()
		{
			InitializeComponent();
			MessagingCenter.Subscribe<UserViewModel, MessageModel>(this, "ShowSignUpAlert", (sender, message) => {
				Device.BeginInvokeOnMainThread(() =>
				{
					DisplayAlert(message.Title, message.Message, "OK");
				});
			});
			MessagingCenter.Subscribe<UserViewModel, Models.API.Authorization>(this, "Signed", (sender, auth) => {
				Device.BeginInvokeOnMainThread(() =>
				{
					Application.Current.Properties["WebToken"] = auth.WebToken;
					Application.Current.Properties["IdUser"] = auth.IdUser;
					Application.Current.Properties["UserName"] = auth.UserName;
					APIClient.WebToken = auth.WebToken;
					MessagingCenter.Send(this, "UserSigned");
					Navigation.PushAsync(new MainPage());
					Navigation.RemovePage(this);
				});
			});
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
	}
}
