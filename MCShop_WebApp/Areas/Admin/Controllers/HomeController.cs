using MCShop_WebApp.Common;
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCShop_WebApp.Areas.Admin.Controllers
{
    [HasCredential(MaQuyenSD = "Admin")]
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        MCShop_DbContext context = new MCShop_DbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        //Them moi 1 quyen sach
        public ActionResult CreateBook()
        {
            List<CATEGORY> listCate = context.CATEGORIES.ToList();
            SelectList cateList = new SelectList(listCate, "IDCATEGORIES", "NAME");
            ViewBag.CATEGORYList = cateList;
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateInput(false)]
        public ActionResult CreateBook(PRODUCT p, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Image/"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    p.IMAGE_NAME = fileUpload.FileName;
                    context.PRODUCTS.Add(p);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                   
                }
            
            }

            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error save data");
            }
            var listBook = from s in context.PRODUCTS select s;
            return View("Index", listBook);
        }

        //Chinh sua 1 quyen sach
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            List<CATEGORY> listCate = context.CATEGORIES.ToList();
            SelectList cateList = new SelectList(listCate, "IDCATEGORIES", "NAME");
            ViewBag.CATEGORYList = cateList;
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PRODUCT p = context.PRODUCTS.SingleOrDefault(n => n.IDPRODUCTS == id);
            return View(p);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id)
        {
            var bookupdate = context.PRODUCTS.Find(id);
            if (TryUpdateModel(bookupdate, "", new string[] { "IDCATEGORIES", "AUTHOR", "DESCRIPTION", "PRICE", "VENDOR", "PRODUCTS_NAME", "IMAGE_NAME", "OLDPRICE" }))
            {
                try 
                {
                    context.Entry(bookupdate).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Error save data");
                }
            }
            return RedirectToAction("Index", "Home");
        }


        //Xoa 1 quyen sach 
        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            PRODUCT p = context.PRODUCTS.SingleOrDefault(n => n.IDPRODUCTS == id);
            if (p == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(p);
        }
        [HttpPost, ActionName("DeleteBook")]
        public ActionResult DeleteConfirm(int id)
        {
            PRODUCT p = context.PRODUCTS.SingleOrDefault(n => n.IDPRODUCTS == id);
            if (p == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            context.PRODUCTS.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}