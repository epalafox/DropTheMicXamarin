using Xamarin.Forms;
using DropTheMic.Models;
using DropTheMic.ViewModels;
namespace DropTheMic.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<LoginViewModel, MessageModel>(this, "ShowAuthorizationAlert", (sender, message) => {
				Device.BeginInvokeOnMainThread(() =>
				{
					DisplayAlert(message.Title, message.Message, "OK");
				});
            });
			MessagingCenter.Subscribe<LoginViewModel, Models.API.Authorization>(this, "UserLogged", (sender, auth) => {
				Device.BeginInvokeOnMainThread(() =>
				{
					Application.Current.Properties["WebToken"] = auth.WebToken;
					Application.Current.Properties["IdUser"] = auth.IdUser;
					Application.Current.Properties["UserName"] = auth.UserName;
					Navigation.PushAsync(new MainPage());
					Navigation.RemovePage(this);
				});
			});
			MessagingCenter.Subscribe<SignUpPage>(this, "UserSigned", (sender) =>{
				Device.BeginInvokeOnMainThread(() =>
				{
					Navigation.RemovePage(this);
				});
			});
        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new SignUpPage());
		}
	}
}
