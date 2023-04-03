using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class ServiceController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Service
        public ActionResult Index()
        {
            var servicedetails = from x in dc.Services select x;
            return View(servicedetails);
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            var getservicedetails = dc.Services.Single(x => x.id == id);
            return View(getservicedetails);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(Services collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Services.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Amin,Manager")]
        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            var getservicedetails = dc.Services.Single(x => x.id == id);
            return View(getservicedetails);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Services collection)
        {
            try
            {
                // TODO: Add update logic here
                Services serviceupdate = dc.Services.Single(x => x.id == id);
                serviceupdate.Name = collection.Name;
                serviceupdate.Cost = collection.Cost;
                serviceupdate.CategoryId = collection.CategoryId;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Amin,Manager")]
        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            var getservicedetails = dc.Services.Single(x => x.id == id);
            return View(getservicedetails);
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Services collection)
        {
            try
            {
                // TODO: Add delete logic here
                var servicedel = dc.Services.Single(x => x.id == id);
                dc.Services.DeleteOnSubmit(servicedel);
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
