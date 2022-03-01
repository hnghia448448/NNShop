using MCShop_WebApp.Common;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCShop_WebApp.Controllers
{
    [IsUser]
    public class UserOrderController : Controller
    {
        MCShop_DbContext db = new MCShop_DbContext();
        // GET: UserOrder
        public ActionResult Success()
        {

            return View();
        }
        public ActionResult Order()
        {
            var ListOrder = from s in db.ORDERS select s;
            return View(ListOrder);
        }
        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ORDER p = db.ORDERS.SingleOrDefault(n => n.IDORDERS == id);
            return View(p);
        }

        [HttpPost, ActionName("EditOrder")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(int id)
        {
            var orderUpdate = db.ORDERS.Find(id);
            if (TryUpdateModel(orderUpdate, "", new string[] {"SHIPNAME", "EMAIL", "PHONE","ADDRESS" }))
            {
                try
                {
                    db.Entry(orderUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Error save data");
                }
            }
            return RedirectToAction("Order", "UserOrder");
        }
        public ActionResult DeleteOrder(int id)
        {
            ORDER order = db.ORDERS.SingleOrDefault(n => n.IDORDERS == id);
            if (order == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(order);
        }
        [HttpPost, ActionName("DeleteOrder")]
        public ActionResult DeleteConfirm(int id)
        {

            ORDER order = db.ORDERS.SingleOrDefault(n => n.IDORDERS == id);
            if (order == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ORDERS.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Order");
        }

    }
}