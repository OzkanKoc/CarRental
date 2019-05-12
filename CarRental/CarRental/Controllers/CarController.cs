using CarRental.Models;
using CarRental.Models.Context;
using CarRental.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        CRDbContext db = new CRDbContext();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.Car.Include("Model").Include("Model.Brand").ToList());
        }

        [HttpPost]
        public ActionResult Index(Car car)
        {
            return View();
        }

        public ActionResult CurrentRentals()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
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
            ViewBag.GearTypeList = Enum.GetNames(typeof(GearType));
            ViewBag.FuelTypeList = Enum.GetNames(typeof(FuelType));
            ViewBag.BodyTypeList = Enum.GetNames(typeof(BodyType));
            TempData["Message"] = "Araç ekleme işlemi başarılı bir şekilde gerçekleştirildi.";
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Car car)
        {
            car.Model = null;
            db.Car.Add(car);
            db.SaveChanges();
            TempData["Message"] = "Araç başarılı bir şekilde kaydedildi.";
            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            var car = db.Car.Include("Model").Include("Model.Brand").FirstOrDefault(c => c.CarId == id);
            ViewBag.ModelOfBrands = GetModelOfBrands();
            ViewBag.ModelList = new SelectList(db.Model.AsNoTracking().ToList(), "ModelId", "Name", car.Model.ModelId);
            ViewBag.BrandList = new SelectList(db.Brand.AsNoTracking().ToList(), "BrandId", "Name", car.Model.Brand.BrandId);
            ViewBag.GearTypeList = Enum.GetNames(typeof(GearType));
            ViewBag.FuelTypeList = Enum.GetNames(typeof(FuelType));
            ViewBag.BodyTypeList = Enum.GetNames(typeof(BodyType));

            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (car != null)
            {
                car.Model = null;
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            TempData["Message"] = "Araç başarılı bir şekilde düzenlendi.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var car = db.Car.Find(id);

            return View(car);
        }

        [HttpPost]
        public ActionResult Delete(Car car)
        {
            if (car != null)
            {
                db.Entry(car).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            TempData["Message"] = "Araç başarılı bir şekilde silindi.";
            return RedirectToAction("Index");
        }

        //Private Parts

        public Dictionary<Brand, List<Model>> GetModelOfBrands()
        {
            var modelOfBrands = new Dictionary<Brand, List<Model>>();
            var brand = db.Brand.ToList();

            foreach (var item in brand)
            {
                modelOfBrands.Add(item, (from m in db.Model
                                         where m.BrandId == item.BrandId
                                         select m).ToList());
            }
            return modelOfBrands;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db?.Dispose();
            }
        }
    }
}