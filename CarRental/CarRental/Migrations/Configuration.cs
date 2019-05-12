namespace CarRental.Migrations
{
    using CarRental.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRental.Models.Context.CRDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarRental.Models.Context.CRDbContext db)
        {
            db.Brand.AddRange(new List<Brand>()
                {
                    new Brand(){Name="Mercedes" },
                    new Brand(){ Name="BMW"},
                    new Brand(){ Name="Opel"},
                    new Brand(){ Name="Renault"},
                    new Brand(){ Name="Peugeot"},
                    new Brand(){ Name="Volvo"},
                    new Brand(){ Name="Audi"},
                    new Brand(){ Name="Tesla"},
                    new Brand(){ Name="Ford"},
                    new Brand(){ Name="Honda"},
                    new Brand(){ Name="Hyundai"},
                    new Brand(){ Name="Fiat"},
                    new Brand(){ Name="Toyota"},
                    new Brand(){ Name="Volkswagen"}
                });

            db.Model.AddRange(new List<Model>() {
                new Model(){BrandId=1,Name="E250"},
                new Model(){BrandId=1,Name="C180"},
                new Model(){BrandId=1,Name="A180"},
                new Model(){BrandId=1,Name="CLA180"},
                new Model(){BrandId=2,Name="520D"},
                new Model(){BrandId=2,Name="320I"},
                new Model(){BrandId=2,Name="X5"},
                new Model(){BrandId=2,Name="X6"},
                new Model(){BrandId=2,Name="418"},
                new Model(){BrandId=2,Name="Z4"},
                new Model(){BrandId=3,Name="Astra"},
                new Model(){BrandId=3,Name="Vectra"},
                new Model(){BrandId=3,Name="Corsa"},
                new Model(){BrandId=4,Name="Megane"},
                new Model(){BrandId=4,Name="Clio"},
                new Model(){BrandId=4,Name="Kango"},
                new Model(){BrandId=5,Name="Partner"},
                new Model(){BrandId=5,Name="3008"},
                new Model(){BrandId=5,Name="306"},
                new Model(){BrandId=5,Name="508"},
                new Model(){BrandId=6,Name="S60"},
                new Model(){BrandId=6,Name="S40"},
                new Model(){BrandId=7,Name="A4"},
                new Model(){BrandId=7,Name="A6"},
                new Model(){BrandId=8,Name="Model S"},
                new Model(){BrandId=8,Name="Model X"},
                new Model(){BrandId=8,Name="Model Y"},
                new Model(){BrandId=8,Name="Model 3"},
                new Model(){BrandId=8,Name="RoadSter"},
                new Model(){BrandId=8,Name="Energy"},
                new Model(){BrandId=9,Name="Fiesta"},
                new Model(){BrandId=9,Name="Mondeo"},
                new Model(){BrandId=10,Name="Civic"},
                new Model(){BrandId=10,Name="Jazz"},
                new Model(){BrandId=11,Name="Accent"},
                new Model(){BrandId=12,Name="Linea"},
                new Model(){BrandId=12,Name="Egea"},
                new Model(){BrandId=13,Name="Corolla"},
                new Model(){BrandId=14,Name="Passat"},
                new Model(){BrandId=14,Name="Jetta"}
            });
        }
    }
}
