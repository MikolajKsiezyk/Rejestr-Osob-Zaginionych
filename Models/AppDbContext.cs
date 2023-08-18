using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RejOsobZaginionych.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("RejDB") { }

        public DbSet<Osoba> Osoby { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        // tutaj możesz dodać dodatkowe pola dla użytkownika, jeśli są potrzebne
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
    }

    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}