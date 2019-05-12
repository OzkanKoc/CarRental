using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entity
{
    public class Car
    {
        public int CarId { get; set; }
        public int ModelId { get; set; }

        [DataType("varchar"), MaxLength(50), Required]
        public string Color { get; set; }

        [DataType("varchar"), MaxLength(30), Required]
        [Index(IsUnique = true)]
        public string PlateNumber { get; set; }

        [DataType("money"), Required]
        public decimal Price { get; set; }

        [Column(TypeName = "date"), Required]
        public DateTime PurchaseDate { get; set; }

        [DataType("varchar"), MaxLength(30), Required]
        public string EngineVolume { get; set; }

        [DataType("varchar"), MaxLength(30), Required]
        public string EnginePower { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [ Required]
        public BodyType  BodyType { get; set; }

        [Required]
        public FuelType Fueltype { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public int MinAgeForRent { get; set; }

        public Model Model { get; set; }
        public List<Customer> Customers { get; set; }
    }
}