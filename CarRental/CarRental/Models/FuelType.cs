using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public enum FuelType
    {
        Seçiniz = 0,
        Diesel = 1,
        Hybrid,
        Gasoline,
        [Display(Name = "Electric Vehicle")]
        Electric
    }
}