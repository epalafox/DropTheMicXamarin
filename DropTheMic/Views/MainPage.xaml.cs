using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DropTheMic.Models.API;
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
			TapGestureRecognizer tapOnNew = new TapGestureRecognizer();
			tapOnNew.Tapped += TapOnNew_Tapped;
			fNewPost.GestureRecognizers.Add(tapOnNew);

			//Handle the Item Selection
			lvPost.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;
			};

			lvPost.ItemTapped += LvPost_ItemTapped;
		}

		void Handle_LogOut(object sender, System.EventArgs e)
		{
			APIClient.WebToken = "";
			Application.Current.Properties.Remove("WebToken");
			Application.Current.Properties.Remove("UserName");
			Application.Current.Properties.Remove("IdUser");
			Navigation.InsertPageBefore(new LoginPage(), this);
			Navigation.PopAsync();
		}
		void TapOnNew_Tapped(object sender, EventArgs e)
		{
			((MainViewModel)BindingContext).IsPosting = true;
		}

		void LvPost_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			Navigation.PushAsync(new PostPage((PostViewModel)e.Item));
		}
	}
}
