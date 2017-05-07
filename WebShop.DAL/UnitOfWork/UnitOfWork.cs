using System;
using System.Diagnostics;
using WebShop.DAL.GenericRepository;

namespace WebShop.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WebShopContext _context = null;
        private GenericRepository<Product> _productRepository;

        public UnitOfWork()
        {
            _context = new WebShopContext();
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }

        public bool Save()
        {
            _context.SaveChanges();
            return true;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Debug.WriteLine("UnitOfWork je oslobodjen");
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}