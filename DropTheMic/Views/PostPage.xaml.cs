using System;
using System.Collections.Generic;
using DropTheMic.ViewModels;
using Xamarin.Forms;

namespace DropTheMic.Views
{
	public partial class PostPage : ContentPage
	{
		public PostPage(PostViewModel post)
		{
			InitializeComponent();
			this.BindingContext = post;

			lvComments.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;
			};

			TapGestureRecognizer tapOnNew = new TapGestureRecognizer();
			tapOnNew.Tapped += TapOnNew_Tapped;
			fNewComment.GestureRecognizers.Add(tapOnNew);
		}

		void TapOnNew_Tapped(object sender, EventArgs e)
		{
			((PostViewModel)BindingContext).IsCommenting = true;
		}
	}
}
