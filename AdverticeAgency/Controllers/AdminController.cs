using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class AdminController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            var admindetails = from x in dc.Admins select x;
            return View(admindetails);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var getadmindetails = dc.Admins.Single(x => x.id == id);
            return View(getadmindetails);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admins collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Admins.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var getadmindetails = dc.Admins.Single(x => x.id == id);
            return View(getadmindetails);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Admins collection)
        {
            try
            {
                // TODO: Add update logic here
                Admins adminupdate = dc.Admins.Single(x => x.id == id);
                adminupdate.Name = collection.Name;
                adminupdate.Surname = collection.Surname;
                adminupdate.Email = collection.Email;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var getadmindetails = dc.Admins.Single(x => x.id == id);
            return View(getadmindetails);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Admins collection)
        {
            try
            {
                // TODO: Add delete logic here
                var admindel = dc.Admins.Single(x => x.id == id);
                dc.Admins.DeleteOnSubmit(admindel);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
