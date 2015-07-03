using System;
using Enum2.OwinProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace Enum2.DemoBank
{
    public partial class Startup
    {
        private void ConfigureAuth(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login"),
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            /*
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
                {
                    ClientId = "",
                    ClientSecret = ""
                });
            */


            app.UseEnumAuthentication(new EnumAuthenticationOptions
            {
                //put here your client id and client secret
                ClientId = "",
                ClientSecret = ""
            });
             
        }
    }
}