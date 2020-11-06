using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.PluginInterfaces.DataStore;
using eShop.DataStore.SQL.Dapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            List<Product> _Products;
            if (string.IsNullOrWhiteSpace(filter))
            {
                _Products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product", new { });
            }
            else
            {
                _Products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product WHERE Name like '%' +@Filter + '%'", new { Filter = filter });
            }
            return _Products;
        }

        public Product GetProduct(int id)
        {
            return dataAccess.QuerySingle<Product, dynamic>("SELECT * FROM Product WHERE ProductId = @ProductId", new { ProductId = id });
            //return _Products.FirstOrDefault(x => x.ProductId == id);
        }
    }
}