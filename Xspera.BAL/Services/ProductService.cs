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
        List<Product> GetListProduct(int brandId = 0);
        Dictionary<string, Product> GetProduct(int productId = 0);
    }
    public class ProductService : IProductService
    {
        private IRepository _repository;
        public ProductService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        public List<Product> GetListProduct(int brandId = 0)
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

        public Dictionary<string,Product>  GetProduct(int productId = 0)
        {
            var result = new Dictionary<string, Product>();
            var productDao = this._repository.GetDao<Product>();  
                var existedProduct = productDao.Find(x => x.Id == productId).FirstOrDefault();
                if (existedProduct == null)
                {
                    result.Add("This product can't found \n please try again later.", null);
                }
                else
                {
                result.Add("Get product completed", existedProduct);
                }             
            return result;
        }
    }
}
