using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZookeeperApp.Models;
using Microsoft.Owin.Security;

namespace ZookeeperApp.App_Start
{
    //This is User manager
    public class ApplicationUserManager : UserManager<ApplicationUser>    //ApplicationUserManager is made in the models class
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            ApplicationDbContext dbContext = context.Get<ApplicationDbContext>();
            IUserStore<ApplicationUser> store = new UserStore<ApplicationUser>(dbContext);
            ApplicationUserManager manager = new ApplicationUserManager(store);

            //this manager can do tons of things. just use dots to understand these features.

            //Email id validation  :o :o 
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            //Password validation
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6
            };

            return manager;
        }
    }

    //This is sign in manager
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, string> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

    }
}