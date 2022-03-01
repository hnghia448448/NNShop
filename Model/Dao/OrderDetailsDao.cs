using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailsDao
    {
        MCShop_DbContext db = null;
        public OrderDetailsDao()
        {
            db = new MCShop_DbContext();
        }
        public bool Insert(ORDER_DETAILS od)
        {
            try
            {
                db.ORDER_DETAILS.Add(od);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
