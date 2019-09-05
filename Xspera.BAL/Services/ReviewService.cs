using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

namespace Xspera.BAL.Services
{
    public interface IReviewService
    {
        Dictionary<bool, string> AddingReview(Review review);
    }
    public class ReviewService : IReviewService
    {
        private IRepository _repository;
        public ReviewService(IRepository myRepository)
        {
            this._repository = myRepository;
        }
        public Dictionary<bool,string> AddingReview(Review review)
        {
            var result = new Dictionary<bool, string>();
            var reviewDao = this._repository.GetDao<Review>();
            var userDao = this._repository.GetDao<User>();
            var productDao = this._repository.GetDao<Product>();
            var checkUser = userDao.Find(c => c.Id == review.UserId).FirstOrDefault();
            var checkProd = productDao.Find(c => c.Id == review.ProductId).FirstOrDefault();
            if (checkUser == null || checkProd == null)
            {
                result.Add(false, "User or Product not exist. \n Please try again later");
                return result;
            }
            reviewDao.Add(review);
            result.Add(true,"Adding review completed.");
            return result;
        }
    }
}
