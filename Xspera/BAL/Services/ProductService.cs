using System.Collections.Generic;
using System.Linq;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

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
                var productsByBrand = productDao.FindAllReference(x => x.BrandId == existedBrand.Id && x.AvailableStatus == 0, "Brand,Review.User").ToList();
                return productsByBrand;
            }

            var products = productDao.FindAllReference(x => x.Id > 0, "Brand,Review.User").OrderByDescending(x => x.DateCreated).Take(10).ToList();
            var sortedProducts = products.Select(x => new Product
            {
                Id = x.Id,
                AvailableStatus = x.AvailableStatus,
                Brand = x.Brand,
                BrandId = x.BrandId,
                Color = x.Color,
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated,
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                Review = x.Review.OrderByDescending(c=>c.DateCreated).ToList()
            });
            return sortedProducts.ToList();
        }

        public Dictionary<string, Product> GetProduct(int productId = 0)
        {
            var result = new Dictionary<string, Product>();
            var productDao = this._repository.GetDao<Product>();
            var existedProduct = productDao.Find(x => x.Id == productId && x.AvailableStatus == 0).FirstOrDefault();
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