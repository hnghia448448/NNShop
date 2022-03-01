using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entity;

namespace MCShop_WebApp.Models
{
    public class CartItem
    {
        public int Quantity { set; get; }
        public long Total { set; get; }
        public PRODUCT PRODUCT { set; get; }
    }
}