using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AzureAdAuth
{
    public partial class App : Application
    {
        // update your Application ID or client ID  
        public static string ApplicationID = "e67ff037-5fd3-4562-8b6b-a409ac4b90ea";

        //modify your Azure tenant  
        public static string tenanturl = "https://login.microsoftonline.com/c18f87b5-3033-4e25-aa12-5641175188ba";

        //Update your return url  
        public static string ReturnUri = "https://website07.azurewebsites.net/";

        //No need to change  
        public static string GraphResourceUri = "https://graph.microsoft.com";

        public static AuthenticationResult AuthenticationResult = null;
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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
