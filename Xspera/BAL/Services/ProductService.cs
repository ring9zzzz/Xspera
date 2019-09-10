using System;
using System.Collections.Generic;
using System.Linq;
using Xspera.Core.Enum;
using Xspera.Core.Models;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

namespace Xspera.BAL.Services
{
    public interface IProductService
    {
        /// <summary>Gets the list product.</summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        List<Product> GetListProduct(int brandId, int pageNo, int pageSize);

        /// <summary>Gets the product.</summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Dictionary<string, Product> GetProduct(int productId = 0);

        /// <summary>Creates the product.</summary>
        /// <param name="productRequest">The product request.</param>
        /// <returns></returns>
        Dictionary<bool, string> CreateProduct(ProductRequest productRequest);
    }

    public class ProductService : IProductService
    {
        private IRepository _repository;

        public ProductService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        /// <summary>Gets the list product.</summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public List<Product> GetListProduct(int brandId, int pageNo, int pageSize)
        {
            string queryProduct = $@"SELECT P.Id,P.AvailableStatus,P.BrandId,P.Color,P.CreatedBy,P.DateCreated,P.[Description],P.[Name],P.Price,
	                                   B.Id,B.[Name],B.[Description]
                                       FROM Product P
	                                   INNER JOIN Brand B ON P.BrandId = B.Id
                                       WHERE (P.BrandId = {brandId} and {brandId} > 0) OR (P.BrandId > 0 and {brandId} = 0)
                                       Order by P.DateCreated DESC";
            var products = this._repository.ExecuteMultiSelectQuery<Product, Brand, Product>(queryProduct, pageNo, pageSize, (x, y) => { x.Brand = y; return x; }).ToList();
            var productIds = products.Select(x => x.Id).ToArray();
            string queryReview = $@"SELECT R.Id,R.Comment,R.DateCreated,R.Email,R.ProductId,R.Rating,R.UserId,
                                       U.Id,U.DateOfBirth,U.Email,U.[Type],U.Username
	                                   FROM Review R
                                       INNER JOIN [User] U ON R.UserId = U.Id
	                                   WHERE R.ProductId IN (0{string.Join(",", productIds)})";
            var reviews = this._repository.ExecuteMultiSelectQuery<Review, User, Review>(queryReview, 0, 0, (x, y) => { x.User = y; return x; }).ToList();
            var joinData = from product in products
                           join review in reviews
                           on product.Id equals review.ProductId into listreview
                           select
                           new Product
                           {
                               Id = product.Id,
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

        /// <summary>Creates the product.</summary>
        /// <param name="productRequest">The product request.</param>
        /// <returns></returns>
        public Dictionary<bool, string> CreateProduct(ProductRequest productRequest)
        {
            var productDao = this._repository.GetDao<Product>();
            var trans = productDao.BeginTransaction();
            var result = new Dictionary<bool, string>();
            try
            {
                var brandDao = this._repository.GetDao<Brand>();
                var userDao = this._repository.GetDao<User>();

                var checkBrand = brandDao.Find(x => x.Id == productRequest.BrandId).FirstOrDefault();
                if (checkBrand == null)
                {
                    result.Add(false, "BrandId is not existed");
                    return result;
                }
                var checkUser = userDao.Find(x => x.Id == productRequest.UserId && x.Type == (int)UserType.Merchant).FirstOrDefault();
                if (checkUser == null)
                {
                    result.Add(false, "User is not existed or do not have permission");
                    return result;
                }
                var newproduct = new Product();
                newproduct.BrandId = checkBrand.Id;
                newproduct.Color = productRequest.Color;
                newproduct.CreatedBy = checkUser.Id;
                newproduct.DateCreated = DateTime.Now;
                newproduct.Description = productRequest.Description;
                newproduct.Name = productRequest.Name;
                newproduct.Price = productRequest.Price;
                newproduct.AvailableStatus = productRequest.AvailableStatus;
                productDao.Add(newproduct);
                result.Add(true, "Created product.");
                trans.Commit();
                return result;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                result.Add(false, ex.Message);
                return result;
            }
        }

        /// <summary>Gets the product.</summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public Dictionary<string, Product> GetProduct(int productId)
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