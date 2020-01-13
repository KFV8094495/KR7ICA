using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Controllers.Model;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.Models.ViewModels;
using ThAmCo.Events.Models;
namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Booking> Booking { get; set; }

        private IHostingEnvironment HostIn { get; }

        public CateringDbContext(DbContextOptions<CateringDbContext> options,
                               IHostingEnvironment env) : base(options)
        {
            HostIn = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("thamco.catering");

            builder.Entity<Menu>();
                   //.HasMany(B => B.Booking)
                   //.WithOne(M => M.Menu)
                  // .HasForeignKey(b => b.MenuId);

            builder.Entity<Booking>()
                   .HasKey(b => new { b.MenuId, b.EventId });

            if (HostIn != null && HostIn.IsDevelopment())
            {
                builder.Entity<Menu>().HasData(
                    new Menu { Id = 1, Starter = "Steamed Prawn", Main = " Chicken Rice", Dessert = "Rasberry Bakewell Tart", Cost = 20.40m },
                    new Menu { Id = 2, Starter = "Garlic Bread", Main = "Peperoni Pizza", Dessert = "Vanilla Pannacotta", Cost = 17.20m },
                    new Menu { Id = 3, Starter = "Carrots Soup", Main = "Oven Baked halami", Dessert = "Cheesecake", Cost = 12.30m },
                    new Menu { Id = 4, Starter = "   Salmon", Main = "Fish & Chips", Dessert = "Victoria Sponge Cake", Cost = 19.95m }
                );
            }

            builder.Entity<Booking>().HasData(
                    new Booking { MenuId = 1, EventId = 1 },
                    new Booking { MenuId = 2, EventId = 2 }
                );


        }


    }
}
