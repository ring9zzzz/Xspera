using System.Collections.Generic;
using System.Linq;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

namespace Xspera.BAL.Services
{
    public interface IProductService
    {
        List<Product> GetListProduct(int brandId, int pageNo, int pageSize );

        Dictionary<string, Product> GetProduct(int productId = 0);

    }

    public class ProductService : IProductService
    {
        private IRepository _repository;

        public ProductService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        //public List<Product> GetListProduct(int brandId = 0)
        //{
        //    var productDao = this._repository.GetDao<Product>();
        //    if (brandId > 0)
        //    {
        //        var brandDao = this._repository.GetDao<Brand>();
        //        var existedBrand = brandDao.Find(x => x.Id == brandId).FirstOrDefault();
        //        var productsByBrand = productDao.FindAllReference(x => x.BrandId == existedBrand.Id && x.AvailableStatus == 0, "Brand,Review.User").ToList();
        //        return productsByBrand;
        //    }

        //    var products = productDao.FindAllReference(x => x.Id > 0, "Brand,Review.User").OrderByDescending(x => x.DateCreated).Take(10).ToList();
        //    var sortedProducts = products.Select(x => new Product
        //    {
        //        Id = x.Id,
        //        AvailableStatus = x.AvailableStatus,
        //        Brand = x.Brand,
        //        BrandId = x.BrandId,
        //        Color = x.Color,
        //        CreatedBy = x.CreatedBy,
        //        DateCreated = x.DateCreated,
        //        Description = x.Description,
        //        Name = x.Name,
        //        Price = x.Price,
        //        Review = x.Review.OrderByDescending(c => c.DateCreated).ToList()
        //    });
        //    return sortedProducts.ToList();
        //}

        public List<Product> GetListProduct(int brandId,int pageNo, int pageSize )
        {
            string queryProduct = $@"SELECT P.Id,P.AvailableStatus,P.BrandId,P.Color,P.CreatedBy,P.DateCreated,P.[Description],P.[Name],P.Price,
	                                   B.Id,B.[Name],B.[Description]
                                       FROM Product P
	                                   INNER JOIN Brand B ON P.BrandId = B.Id
                                       WHERE (P.BrandId = {brandId} and {brandId} > 0) OR (P.BrandId > 0 and {brandId} = 0)
                                       Order by P.DateCreated DESC";
            var products = this._repository.ExecuteMultiSelectQuery<Product,Brand, Product>(queryProduct, pageNo, pageSize , (x,y) => { x.Brand = y; return x; }).ToList();
            var productIds = products.Select(x => x.Id).ToArray();
            string queryReview = $@"SELECT R.Id,R.Comment,R.DateCreated,R.Email,R.ProductId,R.Rating,R.UserId,
                                       U.Id,U.DateOfBirth,U.Email,U.[Type],U.Username 
	                                   FROM Review R 
                                       INNER JOIN [User] U ON R.UserId = U.Id
	                                   WHERE R.ProductId IN ({string.Join(",",productIds)})";
            var reviews = this._repository.ExecuteMultiSelectQuery<Review, User, Review>(queryReview, 0, 0, (x, y) => { x.User = y; return x; }).ToList();
            var joinData = from product in products
                         join review in reviews
                         on product.Id equals review.ProductId into listreview
                         select 
                         new Product
                         { Id = product.Id,
                           Review = listreview.ToList(),
                           Brand = product.Brand,
                           AvailableStatus = product.AvailableStatus,
                           BrandId = product.BrandId,
                           Color = product.Color,
                           CreatedBy = product.CreatedBy,
                           DateCreated = product.DateCreated,
                           Description = product.Description,
                           Name = product.Name,
                           Price = product.Price
                         };
            return joinData.ToList();
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