using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_IntroToEntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }

        [Required]//null => not null
        [MaxLength(100)]
        public string Model { get; set; } 
        public int MaxPassangers { get; set; }

        //Navigation properties

        //Relationship type : one to many (1......*)
        public ICollection<Flight> Flights { get; set; }


    }
}
