using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(App.UI.Web.Startup))]

namespace App.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
               new CookieAuthenticationOptions
               {
                   AuthenticationType = "ApplicationCookie",
                   CookieName = "AuthApp",
                   ExpireTimeSpan = TimeSpan.FromHours(1),
                   LoginPath = new PathString("/Security/Login")
               }
               );
        }
    }
}
