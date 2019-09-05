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
            var productDao = this._repository.GetDao<Product>();
            if (brandId > 0)
            {
                var brandDao = this._repository.GetDao<Brand>();
                var existedBrand = brandDao.Find(x => x.Id == brandId).FirstOrDefault();
                var productsByBrand = productDao.FindAllReference(c => c.BrandId == existedBrand.Id, "Brand,Review.User").ToList();
                return productsByBrand;
            }
       
            var products = productDao.FindAllReference(c => c.Id > 0, "Brand,Review.User").OrderByDescending(x => x.DateCreated).Take(10).ToList();
            return products;
        }
    }
}
