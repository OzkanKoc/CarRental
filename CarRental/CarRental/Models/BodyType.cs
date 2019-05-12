using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public enum BodyType
    {
        Seçiniz = 0,
        Cabrio = 1,
        Coupe,
        HatchkBack,
        Sedan,
        [Display(Name = "Station Wagon")]
        StationWagon,
        Crossover,
        MPV,
        Roadster,
        Pickup,
        SUV
    }
}