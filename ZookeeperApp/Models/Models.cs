using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace ZookeeperApp.Models
{

    //This classes are responsible for identity operations
    public class ApplicationUser : IdentityUser
    {
        //for making claims here
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            ClaimsIdentity claimsIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return claimsIdentity;
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ZooDBContext")
        {

        }

        //This is a factory pattern to create a object of this ApplicationDbContext class without using the typical new keyword
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}