using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AccountDao
    {
        MCShop_DbContext context = null;
        public AccountDao()
        {
            context = new MCShop_DbContext();
        }
        public long Insert(ACCOUNT entity)
        {
            context.ACCOUNTS.Add(entity);
            context.SaveChanges();
            return entity.ID_ACCOUNTS;
        }

        public ACCOUNT GetByID(string userName)
        {
            return context.ACCOUNTS.SingleOrDefault(x => x.EMAIL == userName);
        }
        public int Login(string userName, string password)
        {

            var res = context.ACCOUNTS.SingleOrDefault(x => x.EMAIL == userName);
            if (res == null)
            {
                return 0;
            }
            else if (res.PASSWORD == password && res.PERMISSION == "Admin")
            {
                return 2;
            }
            else if (res.PASSWORD == password && (res.PERMISSION == "User" || res.PERMISSION == null))
            {

                return 1;
            }

            else return 3;
        }

        public bool checkUserName(string userName)
        {
            return context.ACCOUNTS.Count(x => x.EMAIL == userName) > 0;
        }
        
    }
}
