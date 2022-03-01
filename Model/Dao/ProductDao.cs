using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class ProductDao
    {
        MCShop_DbContext context = null;
        public ProductDao()
        {
            context = new MCShop_DbContext();
        }
        public List<string> ListName(string keyword)
        {
            return context.PRODUCTS.Where(x => x.PRODUCTS_NAME.Contains(keyword)).Select(x => x.PRODUCTS_NAME).ToList();
        }
        public IEnumerable<PRODUCT> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PRODUCT> model = context.PRODUCTS;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.AUTHOR.Contains(searchString) || x.PRODUCTS_NAME.Contains(searchString));
            }
            return model.OrderBy(x=>x.IDPRODUCTS).ToPagedList(page, pageSize);
        }
    }
}
