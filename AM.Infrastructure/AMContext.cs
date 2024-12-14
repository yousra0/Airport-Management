using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        //DBSet
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=AirportManagementDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
          optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        //OnModelCreating (FluentAPI)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.Entity<Plane>().HasKey(p=>p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>()
                        .Property(p => p.Capacity)
                        .HasColumnName("PlaneCapacity");
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //Configure Owned Type
            modelBuilder.Entity<Passenger>().OwnsOne(p=>p.FullName);

            //Configurer l'héritage Table Per Hiererachy (TPH)
            //modelBuilder.Entity<Passenger>()
            //            .HasDiscriminator<int>("IsTraveller")
            //            .HasValue<Passenger>(2)
            //            .HasValue<Traveller>(1)
            //            .HasValue<Staff>(0);

            //Configurer l'héritage Table Per Type (TPT)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //Configurer la clé primaire de la porteuse de données
            modelBuilder.Entity<Ticket>()
                        .HasKey(t => new { t.FlightFk, t.PassengerFk });
            base.OnModelCreating(modelBuilder);
        }
        //ConfigureConventions (sur tt le modele)
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("datetime");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
