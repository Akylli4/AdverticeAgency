using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdverticeAgency.Controllers
{
    public class OrdersController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Orders
        public ActionResult Index()
        {
            var ordersdetails = from x in dc.Orderss select x;
            return View(ordersdetails);
        }

        [Authorize(Roles = "Admin")]
        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            var getordersdetails = dc.Orderss.Single(x => x.id == id);
            return View(getordersdetails);
        }

        [Authorize(Roles = "User")]
        public ActionResult IndexId(string categ)
        {
            List<Orderss> Spisok = new List<Orderss>();
            Spisok = dc.Orderss.Where(x => x.CategoryName == categ).Where(x => x.Status == "Доступно").ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult IndexAd()
        {
            List<Orderss> Spisok = new List<Orderss>();
            Spisok = dc.Orderss.Where(x => x.Status == "Обрабатывается").ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "Worker")]
        public ActionResult IndexWork()
        {
            List<Orderss> Spisok = new List<Orderss>();
            Spisok = dc.Orderss.Where(x => x.Status == "Выполняется").ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "User")]
        public ActionResult IndexP(int idp)
        {
            List<Orderss> Spisok = new List<Orderss>();
            Spisok = dc.Orderss.Where(x => x.UserId == idp).ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "User")]
        public ActionResult Index2()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Orderss collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Orderss.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Метод - при оформления заказа клиентом ставит ему статус "обрабатывается"
        [Authorize(Roles = "User")]
        public ActionResult StatusInProcess(int id, string userrId, Orderss collection)
        {
            // TODO: Add insert logic here
            Orderss statement = dc.Orderss.Single(x => x.id == id);
            statement.Status = "Обрабатывается";
            statement.UserId = int.Parse(userrId);
            dc.SubmitChanges();
            return RedirectToAction("IndexId");

        }

        //Заказ подтвержден менеджером-статус "выполняется"
        [Authorize(Roles = "Manager")]
        public ActionResult OrdersConfirmed(int id, Orderss collection)
        {
            // TODO: Add insert logic here
            Orderss statement = dc.Orderss.Single(x => x.id == id);
            statement.Status = "Выполняется";
            dc.SubmitChanges();
            return RedirectToAction("IndexAd");
        }

        //Отказано, статус "отказано"
        [Authorize(Roles = "Manager")]
        public ActionResult OrdersDecline(int id, Orderss collection)
        {
            // TODO: Add insert logic here
            Orderss statement = dc.Orderss.Single(x => x.id == id);
            statement.Status = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("IndexAd");
        }

        [Authorize(Roles = "Admin,Worker,Manager")]
        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var getordersdetails = dc.Orderss.Single(x => x.id == id);
            return View(getordersdetails);
        }

        [Authorize(Roles = "Admin,Worker,Manager")]
        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Orderss collection)
        {
            try
            {
                // TODO: Add update logic here
                Orderss ordersupdate = dc.Orderss.Single(x => x.id == id);
                ordersupdate.CategoryName = collection.CategoryName;
                ordersupdate.ServiceName = collection.ServiceName;
                ordersupdate.Price = collection.Price;
                ordersupdate.ServiceId = collection.ServiceId;
                ordersupdate.CategoryId = collection.CategoryId;
                ordersupdate.WorkerId = collection.WorkerId;
                ordersupdate.UserId = collection.UserId;
                ordersupdate.Status = collection.Status;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            var getordersdetails = dc.Orderss.Single(x => x.id == id);
            return View(getordersdetails);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Orderss collection)
        {
            try
            {
                // TODO: Add delete logic here
                var ordersdel = dc.Orderss.Single(x => x.id == id);
                dc.Orderss.DeleteOnSubmit(ordersdel);
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
