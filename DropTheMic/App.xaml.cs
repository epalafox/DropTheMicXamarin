using Xamarin.Forms;
using DropTheMic.Views;
using DropTheMic.Models.API;

namespace DropTheMic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
			if (Current.Properties.ContainsKey("WebToken") && Current.Properties["WebToken"].ToString() != "")
			{
				APIClient.WebToken = Current.Properties["WebToken"].ToString();
				MainPage = new NavigationPage(new MainPage());
			}
			else
			{
				MainPage = new NavigationPage(new LoginPage());
			}
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
