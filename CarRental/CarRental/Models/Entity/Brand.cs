using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class Brand
    {
        public int BrandId { get; set; }
        [DataType("varchar"), MaxLength(50), Required]
        public string Name { get; set; }
    }
}