using CarRental.Models;
using CarRental.Models.Context;
using CarRental.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class RentalController : Controller
    {
        CRDbContext db = new CRDbContext();
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            RentalWizardModel RentalWizard = new RentalWizardModel();
            RentalWizard.Customer = customer;
            Session["RentalWizard"] = RentalWizard;

            return RedirectToAction("AddLicense");
        }

        public ActionResult CarSelection()
        {
            var modelOfBrands = new Dictionary<Brand, List<Model>>();
            var brand = db.Brand.ToList();

            foreach (var item in brand)
            {
                modelOfBrands.Add(item, (from m in db.Model
                                         where m.BrandId == item.BrandId
                                         select m).ToList());
            }
            ViewBag.ModelOfBrands = modelOfBrands;

            return View();
        }

        [HttpPost]
        public ActionResult CarSelection(RentalWizardModel rentalWizard)
        {
            var sessionRentalWizar = ((RentalWizardModel)Session["RentalWizard"]);
            sessionRentalWizar.Car = db.Car.FirstOrDefault(c => c.CarId == rentalWizard.Car.CarId);

            return RedirectToAction("DateSelection");
        }

        [HttpGet]
        public ActionResult DateSelection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DateSelection(Rental rental)
        {
            var sessionRentalWizar = ((RentalWizardModel)Session["RentalWizard"]);
            rental.CarId = sessionRentalWizar.Car.CarId;

            SaveDrivingLicenseToDb(sessionRentalWizar.DrivingLicense);

            sessionRentalWizar.Customer.DrivingLicenseId = db.DrivingLicense.ToList().Last().DrivingLicenseId;
            SaveCustomerToDb(sessionRentalWizar.Customer);

            rental.CustomerId = db.Customer.ToList().Last().CustomerId;
            SaveRentalToDb(rental);

            TempData["Message"] = "Kiralama işlemi başarılı bir şekilde gerçekleştirildi.";


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddLicense()
        {
            ViewBag.LicenseTypeList = Enum.GetNames(typeof(LicenseType));

            return View();
        }

        [HttpPost]
        public ActionResult AddLicense(DrivingLicense drivingLicense)
        {
            ((RentalWizardModel)Session["RentalWizard"]).DrivingLicense = drivingLicense;
            return RedirectToAction("CarSelection");
        }


        [HttpGet]
        public JsonResult GetCars(int? modelId)
        {
            var cars = (from car in db.Car.ToList()
                        where car.ModelId == modelId
                        select car).ToList();

            var carList = new List<Car>();
            var availableList = new List<string>();
            foreach (var item in cars)
            {
                var rental = (from r in db.Rental.ToList()
                              where r.CarId == item.CarId
                              select r).ToList();

                carList.Add(item);
                availableList.Add(IsAvailable(rental) ? "true" : "false");
            }
            var result = new { Cars = carList, Availables = availableList };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool IsAvailable(List<Rental> rentals)
        {
            foreach (var rental in rentals)
            {
                if (rental != null && rental.ReturnDate >= DateTime.Now)
                {
                    return false;
                }
            }

            return true;
        }

        public ActionResult CurrentRentals()
        {
            return View(db.Rental.Include("Customer").Include("Car").Include("Car.Model").ToList());
        }

        [HttpGet]
        public ActionResult Messages()
        {
            var lastDayRental = db.Rental
                .Include("Car")
                .Include("Customer")
                .Include("Car.Model")
                .Include("Car.Model.Brand")
                .Where(r => r.ReturnDate == DateTime.Today).ToList();

            return PartialView("_Messages", lastDayRental);
        }

        //Private Parts
        private void SaveRentalToDb(Rental rental)
        {
            db.Rental.Add(rental);
            db.SaveChanges();
        }

        private void SaveCustomerToDb(Customer customer)
        {
            customer.Cars = null;
            customer.DrivingLicense = null;
            db.Entry(customer).State = System.Data.Entity.EntityState.Added;
            //db.Customer.Add(customer);
            db.SaveChanges();
        }

        private void SaveDrivingLicenseToDb(DrivingLicense drivingLicense)
        {
            db.DrivingLicense.Add(drivingLicense);
            db.SaveChanges();
        }
    }
}