using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using ZookeeperApp.Models;
using ZookeeperApp.App_Start;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(ZookeeperApp.Startup))]

namespace ZookeeperApp
{
    public class Startup
    {
        //We have created three delegates. Two in IdentityConfig class and one in Models
        //Here we will call every delegates.
        //We could make methods, rather than delegates. And could make object of them by new keyword. 
        //But this consumes huge memory.
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //Context store
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}
