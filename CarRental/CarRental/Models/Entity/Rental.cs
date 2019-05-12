using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class Rental
    {
        public int RentalId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}