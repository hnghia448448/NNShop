using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{

    public class OrderDao
    {
        MCShop_DbContext db = null;
        public OrderDao()
        {
            db = new MCShop_DbContext();
        }
        public int Insert(ORDER order)
        {
            db.ORDERS.Add(order);
            db.SaveChanges();
            return order.IDORDERS;
        }
    }
}
