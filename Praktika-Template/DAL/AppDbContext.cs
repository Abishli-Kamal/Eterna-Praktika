using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.Models;

namespace Praktika_Template.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Statistica> Statics { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutInfo> AboutInfos { get; set; }
        public DbSet<HomeCard> HomeCards { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientImage> ClientImages { get; set; }




    }
}
