using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DataType("varchar"), MaxLength(50), Required]
        public string FirstName { get; set; }

        [DataType("varchar"), MaxLength(50), Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [DataType("varchar"), MaxLength(11), Required]
        public string IdentityNumber { get; set; }

        [Required, DataType("varchar"), MaxLength(20), Phone]
        public string PhoneNumber { get; set; }

        //[Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }

        [DataType("varchar"), MaxLength(3000), Required]
        public string Address { get; set; }

        public int DrivingLicenseId { get; set; }

        public DrivingLicense DrivingLicense { get; set; }
        public List<Car> Cars { get; set; }
    }
}