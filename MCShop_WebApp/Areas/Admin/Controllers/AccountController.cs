using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCShop_WebApp.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        MCShop_DbContext db = new MCShop_DbContext();
        // GET: Admin/Account
        public ActionResult getListAccount()
        {
            var listAcc = from a in db.ACCOUNTS select a;
            return View(listAcc);
        }

        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ACCOUNT account = db.ACCOUNTS.SingleOrDefault(n => n.ID_ACCOUNTS == id);
            return View(account);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var accountUp = db.ACCOUNTS.Find(id);
            if (TryUpdateModel(accountUp, "", new string[] {"USERNAME", "PASSWORD", "PERMISSION" }))
            {
                try
                {
                    db.Entry(accountUp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Error save data");
                }
            }
            return RedirectToAction("getListAccount", "Account");
        }


        //Xoa 1 quyen sach 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ACCOUNT p = db.ACCOUNTS.SingleOrDefault(n => n.ID_ACCOUNTS == id);
            if (p == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(p);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ACCOUNT p = db.ACCOUNTS.SingleOrDefault(n => n.ID_ACCOUNTS == id);
            if (p == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ACCOUNTS.Remove(p);
            db.SaveChanges();
            return RedirectToAction("getListAccount");
        }
    }
}