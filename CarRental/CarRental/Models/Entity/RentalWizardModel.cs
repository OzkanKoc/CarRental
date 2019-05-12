using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class RentalWizardModel
    {
        public Brand Brand { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DrivingLicense DrivingLicense { get; set; }
        public Model Model { get; set; }
        public Rental Rental { get; set; }
        public RentalInformation RentalInformation { get; set; }
    }
}