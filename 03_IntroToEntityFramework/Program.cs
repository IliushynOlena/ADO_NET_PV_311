
using Airplane_Data_Access;
using Airplane_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _03_IntroToEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext dbContext = new AirplaneDbContext();
   
            dbContext.Clients.Add(new Client()
            {
                  Name = "Max",   
                   Email = "max@gmail.com",
                    Birthday = new DateTime(2000,5,12)
            });
            //dbContext.SaveChanges();

            //foreach (var client in dbContext.Clients)
            //{
            //    Console.WriteLine($"{client.Name} . {client.Email} . {client.Birthday}");
            //}

            //Include(relation data)
            var filteredFlight = dbContext.Flights
                .Include(f=>f.Clients)//Flights join Clients
                .Include(f=>f.Airplane)//Flights join Airplanes
                .Where(f => f.ArrivalCity == "Lviv")
                .OrderBy(f => f.ArrivalTime);

            foreach (var flight in filteredFlight)
            {
                Console.WriteLine($"{flight.ArrivalCity} - " +
                    $"{flight.DepartureCity}. " +
                    $"{flight.ArrivalTime}\n" +
                    $"Airplane Id : {flight.AirplaneId}. " +
                    $"Airplane Model : {flight.Airplane?.Model}\n" +
                    $"Count clients : {flight.Clients.Count}");
            }

            var client = dbContext.Clients.Find(1);
            //Explicit data loading : context.Entry(entity).Collection/Reference.Load()
           dbContext.Entry(client).Collection(c => c.Flights).Load();
            Console.WriteLine($"Name : {client.Name}. " +
                $"Count flights : {client.Flights.Count}");
            foreach (var item in client.Flights)
            {
                Console.WriteLine($"{item.ArrivalCity} - {item.DepartureCity}");
            }
           
        }
    }
}
