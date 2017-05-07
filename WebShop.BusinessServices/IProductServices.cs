using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.BusinessEntities;

namespace WebShop.BusinessServices
{
    public interface IProductServices
    {
        ProductEntity GetProductById(int productId);
        IEnumerable<ProductEntity> GetAllProducts();
        void CreateProduct(ProductEntity product);
        void UpdateProduct(ProductEntity product);
    }
}