using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_IntroToEntityFramework.Entities
{
    //Entities
    [Table("Passangers")]
    public class Client
    {
        //Primary key naming : Id/id/ID/EntitiName+ Id
        public int Id { get; set; }
        [Required, MaxLength(100)]
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }// ? - not null -> null
        public int? Rating { get; set; }

        //Navigation properties
        //Relationship type : many to many (*......*)
        public ICollection<Flight> Flights { get; set; }

    }
}
