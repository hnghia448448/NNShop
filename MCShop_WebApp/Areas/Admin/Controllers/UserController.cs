using MCShop_WebApp.Areas.Admin.Models;
using MCShop_WebApp.Common;
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MCShop_WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        MCShop_DbContext db = new MCShop_DbContext();



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                if (dao.checkUserName(model.userName))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else
                {
                    var acc = new ACCOUNT();
                    acc.USERNAME = model.userName;
                    acc.EMAIL = model.Email;
                    acc.PASSWORD = Encryptor.MD5Hash(model.password);
                    var res = dao.Insert(acc);
                    if (res > 0)
                    {
                        model = new RegisterModel();
                        ViewBag.TB = "Đăng ký thành công.";
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ACCOUNT model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var res = dao.Login(model.EMAIL, Encryptor.MD5Hash(model.PASSWORD));
                if (res == 1)
                {

                    var user = dao.GetByID(model.EMAIL);
                    var userSession = new ACCOUNT();
                    userSession.EMAIL = user.EMAIL;
                    userSession.USERNAME = user.USERNAME;
                    
                    userSession.ID_ACCOUNTS = user.ID_ACCOUNTS;
                    userSession.PASSWORD = user.PASSWORD;
                    userSession.PERMISSION = user.PERMISSION;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "../Book");

                }
                if (res == 2)
                {
                    var user = dao.GetByID(model.EMAIL);
                    var userSession = new ACCOUNT();
                    userSession.EMAIL = user.EMAIL;
                    userSession.USERNAME = user.USERNAME;
                    userSession.PASSWORD = user.PASSWORD;
                    userSession.ID_ACCOUNTS = user.ID_ACCOUNTS;
                    userSession.PERMISSION = user.PERMISSION;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhập không tồn tại. Vui lòng thử lại.");
                }
                else ModelState.AddModelError("", "Mật khẩu không đúng vui vòng nhập lại mật khẩu");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "User");
        }
        [IsUser]
        public ActionResult ChangePassword()
        {

            return View();
        }
        [HttpPost, ActionName("ChangePassword")]
        public ActionResult Confirm(ChangePassModel model)
        {
            if (ModelState.IsValid)
            {
                var session = (ACCOUNT)Session[CommonConstants.USER_SESSION];
                int id = session.ID_ACCOUNTS;
                string oldp = session.PASSWORD;
                if (oldp == Encryptor.MD5Hash(model.oldPass))
                {

                    var accNew = db.ACCOUNTS.Find(session.ID_ACCOUNTS);
                    accNew.PASSWORD = Encryptor.MD5Hash(model.newPass);
                    db.SaveChanges();

                    Session[CommonConstants.USER_SESSION] = null;
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error");
            }
            return View(model);
        }

    }
}