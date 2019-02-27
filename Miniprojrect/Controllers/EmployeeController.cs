using Miniprojrect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Miniprojrect.Controllers
{

    [Authorize(Roles = "Employee,Admin")]
    public class EmployeeController : Controller
    {
        private Training_12DecMumbaiEntities3 db = new Training_12DecMumbaiEntities3();


        //GET: Employee
        public ActionResult Index(string SearchBy, int? search)
        {
            if (SearchBy == "OrderId")
            {
                var model = db.ProjectOrders.Where(emp => emp.OrderId == search || search == null).ToList();
                View(model);
            }
            else
            {
                var model = db.ProjectOrders.Where(emp => emp.UserId == search || search == null).ToList();
                View(model);
            }
            return View();
        }


        //public ActionResult Search(string SearchBy, int? search)
        //{
        //    if (SearchBy == "PizzaId")
        //    {
        //        var model = db.ProjectOrders.Where(emp => emp.OrderId == search || search == null).ToList();
        //        View(model);
        //    }
        //    else
        //    {
        //        var model = db.ProjectOrders.Where(emp => emp.PizzaID == search || search == null).ToList();
        //        View(model);
        //    }
        //    return View();
        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectOrder projectOrder = db.ProjectOrders.Find(id);
            if (projectOrder == null)
            {
                return HttpNotFound();
            }
            return View(projectOrder);
        }

        // GET: ProjectOrders/Create
        public ActionResult Create()
        {
            ViewBag.PizzaID = new SelectList(db.ProjectPizzas, "PizzaID", "PName");
            ViewBag.UserId = new SelectList(db.ProjectUsers, "UserId", "UserId");
            return View();
        }

        // POST: ProjectOrders/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderStatus,TotalPrice,DeliveryDateTime,UserId,PizzaID")] ProjectOrder projectOrder)
        {
            if (ModelState.IsValid)
            {
                db.ProjectOrders.Add(projectOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PizzaID = new SelectList(db.ProjectPizzas, "PizzaID", "PName", projectOrder.PizzaID);
            ViewBag.UserId = new SelectList(db.ProjectUsers, "UserId", "FName", projectOrder.UserId);
            return View(projectOrder);
        }

        // GET: ProjectOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectOrder projectOrder = db.ProjectOrders.Find(id);
            if (projectOrder == null)
            {
                return HttpNotFound();
            }

            ViewBag.PizzaID = new SelectList(db.ProjectPizzas, "PizzaID", "PName", projectOrder.PizzaID);
            ViewBag.UserId = new SelectList(db.ProjectUsers, "UserId", "FName", projectOrder.UserId);
            return View(projectOrder);
        }

        // POST: ProjectOrders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderStatus,TotalPrice,DeliveryDateTime,UserId,PizzaID")] ProjectOrder projectOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectOrder).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PizzaID = new SelectList(db.ProjectPizzas, "PizzaID", "PName", projectOrder.PizzaID);
            ViewBag.UserId = new SelectList(db.ProjectUsers, "UserId", "FName", projectOrder.UserId);
            return View(projectOrder);
        }

        // GET: ProjectOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectOrder projectOrder = db.ProjectOrders.Find(id);
            if (projectOrder == null)
            {
                return HttpNotFound();
            }
            return View(projectOrder);
        }

        // POST: ProjectOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectOrder projectOrder = db.ProjectOrders.Find(id);
            db.ProjectOrders.Remove(projectOrder);
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


    }


}