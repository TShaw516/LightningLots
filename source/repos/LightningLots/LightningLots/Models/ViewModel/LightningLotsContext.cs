using Microsoft.EntityFrameworkCore;
using LightningLots.Models.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace LightningLots.Models.ViewModel
{
        public class LightningLotsContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Lot> Lot { get; set; }

            public LightningLotsContext(DbContextOptions<LightningLotsContext> options)
                : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LightningLots;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString)
                    .UseLazyLoadingProxies();

                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Lot>().HasData(
                    new Lot
                    {
                        Id = 1,
                        LotName = "1234",
                        Weight = 10.00,

                    });
                modelBuilder.Entity<Reagent>().HasData(
                    new Reagent
                    {
                        Id = 1,
                        Name = "ATP",
                        Weight = 5.05,
                        ReceiptTimeStamp = DateTime.Today,
                        IsQuarantineComplete = true,
                        LotId = 1
                    });
            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        FirstName = "Tom",
                        LastName = "Shaw",
                        City = "Akron",
                        State = "Ohio"
                    });



                base.OnModelCreating(modelBuilder);
            }

        }
}
