using MCShop_WebApp.Common;
using MCShop_WebApp.Models;
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MCShop_WebApp.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        MCShop_DbContext context = new MCShop_DbContext();

        // GET: CartItem
        [HttpPost]
        public JsonResult AddToCart(int id)
        {

            //Process Add To Cart1
            List<CartItem> listCartItem;
            if (Session["ShoppingCart"] == null)
            {
                //Create New Shopping Cart Session 
                listCartItem = new List<CartItem>();
                listCartItem.Add(new CartItem { Quantity = 1, PRODUCT = context.PRODUCTS.Find(id) });
                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>)Session["ShoppingCart"];
                foreach (CartItem item in listCartItem)
                {
                    if (item.PRODUCT.IDPRODUCTS == id)
                    {
                        item.Quantity++; flag = true;
                        break;
                    }
                }

                if (!flag)
                    listCartItem.Add(new CartItem { Quantity = 1, PRODUCT = context.PRODUCTS.Find(id) });

                Session["ShoppingCart"] = listCartItem;
            }
            //Count item in shopping cart 
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            foreach (CartItem item in ls)
            {
                cartcount += item.Quantity;
            }
            return Json(new { ItemAmount = cartcount });
        }
        public ActionResult ShoppingCart()
        {
            return View();
        }
        public JsonResult DeleteAll()
        {
            Session["ShoppingCart"] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session["ShoppingCart"];
            sessionCart.RemoveAll(x => x.PRODUCT.IDPRODUCTS == id);
            Session["ShoppingCart"] = sessionCart;
            //Session["ShoppingCart"] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session["ShoppingCart"];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.PRODUCT.IDPRODUCTS == item.PRODUCT.IDPRODUCTS);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session["ShoppingCart"] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        [IsUser]
        public ActionResult Payment()
        {
            var cart = Session["ShoppingCart"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        [IsUser]
        public ActionResult Payment(string shipname, string email, string mobile, string address)
        {
            var session = (ACCOUNT)Session[CommonConstants.USER_SESSION];
            var order = new ORDER();
            order.ID_ACCOUNTS = session.ID_ACCOUNTS;
            order.SHIPNAME = shipname;
            order.EMAIL = email;
            order.PHONE = mobile;
            order.STATUS = "Chờ xác nhận";
            order.ADDRESS = address;

            try
            {
                int id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session["ShoppingCart"];
                var detailDao = new OrderDetailsDao();
                foreach (var item in cart)
                {
                    var orderDetait = new ORDER_DETAILS();
                    orderDetait.IDPRODUCTS = item.PRODUCT.IDPRODUCTS;
                    orderDetait.IDORDERS = id;
                    orderDetait.QUANTITY = item.Quantity;
                    orderDetait.TOTAL = item.Total;
                    detailDao.Insert(orderDetait);
                }
            }
                catch 
            {

            }
            return RedirectToAction("Success", "UserOrder");
        }
    }
}
