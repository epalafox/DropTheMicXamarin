using Xamarin.Forms;

namespace DropTheMic
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnLogin.Clicked += (sender, ea) => {
                DisplayAlert("Alert", "You have been alerted", "OK");
            };
        }
    }
}
