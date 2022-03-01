using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace MCShop_WebApp.Controllers
{
    public class BookController : Controller
    {
        MCShop_DbContext context = new MCShop_DbContext();
       
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var viewModel = context.PRODUCTS.SingleOrDefault(s => s.IDPRODUCTS == id);
            return View(viewModel);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}