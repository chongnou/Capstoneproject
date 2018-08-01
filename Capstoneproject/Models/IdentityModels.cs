﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Capstoneproject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<NightLife> NightLives { get; set; }
        public DbSet<Registerforevent> Registerforevents { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EventComments> Eventcomments { get; set; }
        public DbSet<Restaurantcomments> Restaurantcomments { get; set; }
        public DbSet<Barcomments> Barcomments { get; set; }
        public DbSet<Reserveatable> Reserveatables { get; set; }
        public DbSet<Reserveviptable> Reserveviptables { get; set; }
    }
}