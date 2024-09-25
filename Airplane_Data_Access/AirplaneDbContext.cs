
using Airplane_Data_Access.Entities;
using Airplane_Data_Access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_Data_Access
{
    public class AirplaneDbContext: DbContext
    {
        //Collections
        //Clients
        //Flights
        //Airplane
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;
                                            Initial Catalog=AirportDb_PV_311;
                                            Integrated Security=True;
                                            Connect Timeout=2;
                                            Encrypt=False;Trust Server Certificate=False;
                                            Application Intent=ReadWrite;
                                            Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Validation 
            //Fluent API configuration 
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>().Property(c=>c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);//set primary key
            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureCity)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalCity)
                .HasMaxLength(100)
                .IsRequired();
            //Navigation properties
            modelBuilder.Entity<Airplane>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airplane)
                .HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Flights)
                .WithMany(f => f.Clients);


          
            //Initialization - Seeder
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
        }

    }
}
