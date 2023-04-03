using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class CategoryController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Category
        public ActionResult Index()
        {
            var categorydetails = from x in dc.Categories select x;
            return View(categorydetails);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var getcategorydetails = dc.Categories.Single(x => x.id == id);
            return View(getcategorydetails);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Categories collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Categories.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var getcategorydetails = dc.Categories.Single(x => x.id == id);
            return View(getcategorydetails);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categories collection)
        {
            try
            {
                // TODO: Add update logic here
                Categories categoryupdate = dc.Categories.Single(x => x.id == id);
                categoryupdate.Name = collection.Name;
                categoryupdate.CompleteDate = collection.CompleteDate;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var getcategorydetails = dc.Categories.Single(x => x.id == id);
            return View(getcategorydetails);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categories collection)
        {
            try
            {
                // TODO: Add delete logic here
                var categorydel = dc.Categories.Single(x => x.id == id);
                dc.Categories.DeleteOnSubmit(categorydel);
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
