using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessTrips.Model
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        private DateTime _date = DateTime.MinValue;

        [Required]
        public DateTime Date
        {

            get => _date;
            set => _date = value;
        }

        [Range(0,double.MaxValue)]
        public decimal Distance { get; set; }

        [Required]
        public Address StartAddress { get; set; }

        [Required]
        public Address DestinationAddress { get; set; }
    }
}
