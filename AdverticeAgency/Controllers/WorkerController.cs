using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class WorkerController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Worker
        public ActionResult Index()
        {
            var workerdetails = from x in dc.Workers select x;
            return View(workerdetails);
        }

        // GET: Worker/Details/5
        public ActionResult Details(int id)
        {
            var getworkerdetails = dc.Workers.Single(x => x.id == id);
            return View(getworkerdetails);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        public ActionResult Create(Workers collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Workers.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int id)
        {
            var getworkerdetails = dc.Workers.Single(x => x.id == id);
            return View(getworkerdetails);
        }

        // POST: Worker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Workers collection)
        {
            try
            {
                // TODO: Add update logic here
                Workers workerupdate = dc.Workers.Single(x => x.id == id);
                workerupdate.Name = collection.Name;
                workerupdate.Surname = collection.Surname;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int id)
        {
            var getworkerdetails = dc.Workers.Single(x => x.id == id);
            return View(getworkerdetails);
        }

        // POST: Worker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Workers collection)
        {
            try
            {
                // TODO: Add delete logic here
                var workerdel = dc.Workers.Single(x => x.id == id);
                dc.Workers.DeleteOnSubmit(workerdel);
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
