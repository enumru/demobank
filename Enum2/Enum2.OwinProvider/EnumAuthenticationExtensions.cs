using System;
using Owin;

namespace Enum2.OwinProvider
{
    public static class EnumAuthenticationExtensions
    {
        public static IAppBuilder UseEnumAuthentication(this IAppBuilder app,
            EnumAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            if (options == null)
                throw new ArgumentNullException("options");

            app.Use(typeof(EnumAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseEnumAuthentication(this IAppBuilder app, string clientId, string clientSecret)
        {
            return app.UseEnumAuthentication(new EnumAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}