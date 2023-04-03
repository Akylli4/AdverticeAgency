using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class AgencyCrudController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: AgencyCrud
        public ActionResult Index()
        {
            var userdetails = from x in dc.Users select x;
            return View(userdetails);
        }

        // GET: AgencyCrud/Details/5
        public ActionResult Details(int id)
        {
            var getuserdetails = dc.Users.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // GET: AgencyCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgencyCrud/Create
        [HttpPost]
        public ActionResult Create(Users collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Users.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgencyCrud/Edit/5
        public ActionResult Edit(int id)
        {
            var getuserdetails = dc.Users.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // POST: AgencyCrud/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Users collection)
        {
            try
            {
                // TODO: Add update logic here
                Users userupdate=dc.Users.Single(x=>x.id==id);
                userupdate.Name=collection.Name;
                userupdate.Surname = collection.Surname;
                userupdate.Email=collection.Email;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgencyCrud/Delete/5
        public ActionResult Delete(int id)
        {
            var getuserdetails = dc.Users.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // POST: AgencyCrud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Users collection)
        {
            try
            {
                // TODO: Add delete logic here
                var userdel=dc.Users.Single(x=>x.id== id);  
                dc.Users.DeleteOnSubmit(userdel);
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
