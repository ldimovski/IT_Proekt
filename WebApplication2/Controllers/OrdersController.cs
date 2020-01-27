using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;
namespace WebApplication2.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            return View(db.Orders.ToList());

            else
            {
                var email = db.Users.Where(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Email;
                List<Order> results = new List<Order>();
                foreach (Order item in db.Orders)
                {
                    if (string.Compare(item.Od, email) == 0)
                    {
                        results.Add(item);
                    }
                }

                return View(results);
            }
        }


        // GET: Orders/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            


            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var lista = db.Warehouses.ToList();
            var viewModel = new orders_warehouses
            {
                magacini = lista,
            };
            return View(viewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "naracki, magacini")] orders_warehouses ow)
        {
            Order order = new Order();
            order.warehouse_id = ow.naracki.warehouse_id;
            order.kolicina = ow.naracki.kolicina;
            order.kraen_datum = ow.naracki.kraen_datum;
            order.poceten_datum = ow.naracki.poceten_datum;
            order.Opis = ow.naracki.Opis;

            var email = db.Users.Where(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Email;

            order.Od = email.ToString();
            order.approved = "Pending";
            order.Id = ow.naracki.Id;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,warehouse_id,kolicina,poceten_datum,kraen_datum,Od,Opis,approved")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            Order order2 = db.Orders.Find(id);
            db.Orders.Remove(order2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ApproveOrd (int id)
        {
            Order order2 = db.Orders.Find(id);
            order2.approved = "Approved";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult get_by_id(int id)
        {
            List<Order> naracki = new List<Order>();
            Order naracki2 = new Order();
            string datumi;
            datumi = "";
            int i = 1;
            foreach (Order item in db.Orders)
            {
                if (item.warehouse_id == id)
                {
                    naracki.Add(item);
                    naracki2 = item;
                    //break;
                    datumi = datumi + "<p> <h4>Order " + i + ":</h4><br /><strong>Start: </strong>" + item.poceten_datum.ToString("dd.MM.yyyy") + " <strong>End: </strong>" + item.kraen_datum.ToString("dd.MM.yyyy") + " <strong>Capacity: </strong>" + item.kolicina + "</p> <br /> ";
                    i++;
                }
                
            }
            if (string.Compare(datumi, "") == 0)
            {
                datumi = datumi + "No orders on this warehouse.";
            }

            return Json(datumi.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}
