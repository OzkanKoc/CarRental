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
    public class CustomerController : Controller
    {
        CRDbContext db = new CRDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer.Include("DrivingLicense").AsNoTracking().ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            var customer = db.Customer.Include("DrivingLicense").FirstOrDefault(c => c.CustomerId == id);

            ViewBag.DrivingLicenseList = new SelectList(Enum.GetNames(typeof(LicenseType)), "DrivingLicense.LicenseType", "DrivingLicense.DrivingLicenseId", customer.DrivingLicenseId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (customer != null)
            {
                var license = db.DrivingLicense.FirstOrDefault(d => d.DrivingLicenseId == customer.DrivingLicense.DrivingLicenseId);
                license.LicenseType = customer.DrivingLicense.LicenseType;
                customer.DrivingLicenseId = license.DrivingLicenseId;
                db.Entry(license).State = System.Data.Entity.EntityState.Modified;
                customer.DrivingLicense = null;
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Customer.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var cust = db.Customer.Find(customer.CustomerId);
            var license = db.DrivingLicense.FirstOrDefault(l => l.DrivingLicenseId == cust.DrivingLicenseId);
            db.Entry(license).State = System.Data.Entity.EntityState.Deleted;
            db.Entry(cust).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditLicense(int? id)
        {
            return View();
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