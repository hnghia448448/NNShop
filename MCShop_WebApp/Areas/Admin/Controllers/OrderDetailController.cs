using MCShop_WebApp.Common;
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCShop_WebApp.Areas.Admin.Controllers
{
    [HasCredential(MaQuyenSD = "Admin")]
    public class OrderDetailController : BaseController
    {
        // GET: Admin/OrderDetail
        MCShop_DbContext db = new MCShop_DbContext();
        public ActionResult lisrOrder()
        {
            
            var listOrder = (from order in db.ORDERS
                             join orderdetail in db.ORDER_DETAILS on order.IDORDERS equals orderdetail.IDORDERS 
                             join pro in db.PRODUCTS on orderdetail.IDPRODUCTS equals pro.IDPRODUCTS

                             select new OrderdetailInOrder
                             {
                                 IDORDERS = order.IDORDERS,
                                 ID_ACCOUNTS = order.ID_ACCOUNTS,
                                 SHIPNAME = order.SHIPNAME,
                                 PHONE = order.PHONE,
                                 EMAIL = order.EMAIL,

                                 ADDRESS= order.ADDRESS,
                                 PRODUCTS_NAME = pro.PRODUCTS_NAME,
                                 QUANTITY = orderdetail.QUANTITY

                             });
            return View(listOrder);
        }
        public ActionResult Index()
        {
            var List = from s in db.ORDERS select s;
            return View(List);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ORDER p = db.ORDERS.SingleOrDefault(n => n.IDORDERS == id);
            return View(p);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var bookupdate = db.ORDERS.Find(id);
            if (TryUpdateModel(bookupdate, "", new string[] {"STATUS"}))
            {
                try
                {
                    db.Entry(bookupdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Error save data");
                }
            }
            return RedirectToAction("Index", "OrderDetail");
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
            return RedirectToAction("Index");
        }
    }
}