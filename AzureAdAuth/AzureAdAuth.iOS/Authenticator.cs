using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureAdAuth.iOS;
using Foundation;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(Authenticator))]  
namespace AzureAdAuth.iOS
{
    public class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string tenantUrl, string graphResourceUri, string ApplicationID, string returnUri)
        {
            try
            {
                var authContext = new AuthenticationContext(tenantUrl);
                if (authContext.TokenCache.ReadItems().Any()) authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().FirstOrDefault().Authority);
                var authResult = await authContext.AcquireTokenAsync(graphResourceUri, ApplicationID, new Uri(returnUri), new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController));
                return authResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}