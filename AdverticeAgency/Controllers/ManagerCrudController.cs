using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class ManagerCrudController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: ManagerCrud
        public ActionResult Index()
        {
            var managerdetails = from x in dc.Managers select x;
            return View(managerdetails);
        }

        // GET: ManagerCrud/Details/5
        public ActionResult Details(int id)
        {
            var getmanagerdetails = dc.Managers.Single(x => x.id == id);
            return View(getmanagerdetails);
        }

        // GET: ManagerCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerCrud/Create
        [HttpPost]
        public ActionResult Create(Managers collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Managers.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerCrud/Edit/5
        public ActionResult Edit(int id)
        {
            var getmanagerdetails = dc.Managers.Single(x => x.id == id);
            return View(getmanagerdetails);
        }

        // POST: ManagerCrud/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Managers collection)
        {
            try
            {
                // TODO: Add update logic here
                Managers managerupdate = dc.Managers.Single(x => x.id == id);
                managerupdate.Name = collection.Name;
                managerupdate.Surname = collection.Surname;
                managerupdate.Email = collection.Email;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerCrud/Delete/5
        public ActionResult Delete(int id)
        {
            var getmanagerdetails = dc.Managers.Single(x => x.id == id);
            return View(getmanagerdetails);
        }

        // POST: ManagerCrud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Managers collection)
        {
            try
            {
                // TODO: Add delete logic here
                var managerdel = dc.Managers.Single(x => x.id == id);
                dc.Managers.DeleteOnSubmit(managerdel);
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
