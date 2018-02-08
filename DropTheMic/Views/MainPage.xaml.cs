using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DropTheMic.ViewModels;

using Xamarin.Forms;

namespace DropTheMic.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
			lvPost.ItemsSource = ((MainViewModel)BindingContext).Posts;
			MessagingCenter.Subscribe<MainViewModel, ObservableCollection<PostViewModel>>(this, "PostsLoaded", (sender, data) => {
				Device.BeginInvokeOnMainThread(() =>
				{
					lvPost.ItemsSource = data;
				});
			});
			TapGestureRecognizer cgr = new TapGestureRecognizer();
			cgr.Tapped += Cgr_Tapped;
 			alNewPost.GestureRecognizers.Add(cgr);
		}

		void Handle_Activated(object sender, System.EventArgs e)
		{
			Models.API.APIClient.WebToken = "";
			Application.Current.Properties.Remove("WebToken");
			Application.Current.Properties.Remove("IdUser");
			Navigation.InsertPageBefore(new LoginPage(), this);
			Navigation.PopAsync();
		}
		void Cgr_Tapped(object sender, EventArgs e)
		{
			((MainViewModel)BindingContext).IsPosting = true;
		}
	}
}
