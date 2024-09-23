using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_IntroToEntityFramework.Entities
{
    public class Flight
    {
        public int Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }

        //Navigation properties
        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
