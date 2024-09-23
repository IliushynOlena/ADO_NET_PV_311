using _03_IntroToEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _03_IntroToEntityFramework.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
           {
                new Airplane { Id = 1,   Model = "AN 225", MaxPassangers = 300 },
                new Airplane { Id = 2,   Model = "Mria", MaxPassangers = 100 },
                new Airplane { Id = 3,   Model = "Boeing 747", MaxPassangers = 200 }
           });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
         {
                new Flight()
                {
                     Number = 1,
                     DepartureCity = "Rivne",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,09,25),
                     ArrivalTime = new DateTime(2024,09,25),
                     AirplaneId = 1
                },
                  new Flight()
                {
                     Number = 2,
                     DepartureCity = "Kyiv",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,09,25),
                     ArrivalTime = new DateTime(2024,09,25),
                     AirplaneId = 2
                },
                    new Flight()
                {
                     Number = 3,
                     DepartureCity = "Warshaw",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,09,25),
                     ArrivalTime = new DateTime(2024,09,25),
                     AirplaneId =3
                },
         });
        }
    }
}
