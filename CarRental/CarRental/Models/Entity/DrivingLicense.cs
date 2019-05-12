using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class DrivingLicense
    {
        public int DrivingLicenseId { get; set; }

        [Required, DataType("varchar"), MaxLength(10)]
        public string LicenseNumber { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [ Required]
        public LicenseType LicenseType { get; set; }
    }
}