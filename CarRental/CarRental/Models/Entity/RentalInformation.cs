using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class RentalInformation
    {
        public int RentalInformationId { get; set; }
        public int RentalId { get; set; }
        [Required]
        public ReturnReason ReturnReason { get; set; }

        public Rental Rental { get; set; }
    }
}