using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airplane_Data_Access.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; } 
        public int MaxPassangers { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }



    }
}
