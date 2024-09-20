using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_IntroToEntityFramework.Entities
{
    public class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }

        //Navigation properties
        //Relationship type : one to many (1......*)
        public Airplane Airplane { get; set; }
        //Foreight key naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }//foreight key
        //Relationship type : many to many (*......*)
        public ICollection<Client> Clients { get; set; }

    }
}
