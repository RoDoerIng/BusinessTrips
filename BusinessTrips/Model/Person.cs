using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessTrips.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}
