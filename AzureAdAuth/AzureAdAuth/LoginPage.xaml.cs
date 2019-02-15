using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureAdAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                var data = await DependencyService.Get<IAuthenticator>()
                  .Authenticate(App.tenanturl, App.GraphResourceUri, App.ApplicationID, App.ReturnUri);
                App.AuthenticationResult = data;
                NavigateTopage(data);

            }
            catch (Exception)
            {

            }
        }

        private async void NavigateTopage(AuthenticationResult data)
        {
            try
            {
                var userName = data.UserInfo.GivenName + " " + data.UserInfo.FamilyName;
                await Navigation.PushModalAsync(new MainPage(userName));

            }
            catch(Exception ex)
            {

            }
        }
    }
}