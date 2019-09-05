using System;
using System.Collections.Generic;
using System.Text;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;
using System.Linq;

namespace Xspera.BAL.Services
{
    public interface IProductService
    {
        List<Product> GetProduct(int brandId = 0);
    }
    public class ProductService : IProductService
    {
        private IRepository _repository;
        public ProductService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        public List<Product> GetProduct(int brandId = 0)
        {
            if (brandId > 0)
            {
                var brandDao = this._repository.GetDao<Brand>();
                var brand = brandDao.FindAllReference(c => c.Id > 0, "Product.Review.User").Where(x=>x.Id == brandId).FirstOrDefault();
                return brand.Product.ToList();
            }
            var productDao = this._repository.GetDao<Product>();
            var product = productDao.FindAllReference(c => c.Id > 0, "Review.User").OrderByDescending(x => x.DateCreated).Take(10).ToList();
            return product;
        }
    }
}
