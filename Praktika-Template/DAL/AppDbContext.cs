using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.Models;

namespace Praktika_Template.DAL
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Statistica> Statics { get; set; }

    }
}
