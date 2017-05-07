using System.Collections.Generic;
using System.Linq;
using WebShop.BusinessEntities;
using WebShop.DAL;
using WebShop.DAL.UnitOfWork;

namespace WebShop.BusinessServices
{
    public class ProductServices : IProductServices
    {
        private UnitOfWork _unitOfWork;

        public ProductServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductEntity GetProductById(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetById(productId);
            if (product != null)
            {
                var productEntity = new ProductEntity();
                productEntity.Id = product.Id;
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                productEntity.Stock = product.Stock;
                productEntity.IsActive = product.IsActive;
                return productEntity;
            }
            return null;
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();
            if (products.Any())
            {
                var productEntites = new List<ProductEntity>();
                foreach (var p in products)
                {
                    productEntites.Add( new ProductEntity()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock,
                        IsActive = p.IsActive
                    });
                }
                return productEntites;
            }
            return null;
        }

        public void CreateProduct(ProductEntity product)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(ProductEntity product)
        {
            var item = _unitOfWork.ProductRepository.GetById(product.Id);
            if (item != null)
            {
                item.Id = product.Id;
                item.Name = product.Name;
                item.Price = product.Price;
                item.Stock = product.Stock;
                item.IsActive = product.IsActive;
                _unitOfWork.ProductRepository.Update(item);
                _unitOfWork.Save();
            }
        }
    }
}