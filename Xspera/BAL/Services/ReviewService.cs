using System;
using System.Collections.Generic;
using System.Linq;
using Xspera.Core.Enum;
using Xspera.Core.Models;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

namespace Xspera.BAL.Services
{
    public interface IReviewService
    {
        Dictionary<bool, string> AddingReview(ReviewRequest reviewRequest);
    }

    public class ReviewService : IReviewService
    {
        private IRepository _repository;

        public ReviewService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        public Dictionary<bool, string> AddingReview(ReviewRequest reviewRequest)
        {
            using (var trans = this._repository.BeginTransaction())
            {
                var result = new Dictionary<bool, string>();
                try
                {                 
                    var reviewDao = this._repository.GetDao<Review>();
                    var userDao = this._repository.GetDao<User>();
                    var productDao = this._repository.GetDao<Product>();
                    var checkUser = userDao.Find(x => x.Type == (int)UserType.Customer).FirstOrDefault();
                    if (checkUser == null || checkUser.Type == (int)UserType.Merchant)
                    {
                        result.Add(false, "User not exist or do not have permission. \n Please try again later");
                        return result;
                    }
                    var checkProd = productDao.Find(x => x.Id == reviewRequest.ProductId).FirstOrDefault();
                    if (checkProd == null)
                    {
                        result.Add(false, "Product not exist. \n Please try again later");
                        return result;
                    }
                    var newReview = new Review();
                    newReview.ProductId = reviewRequest.ProductId;
                    newReview.UserId = checkUser.Id;
                    newReview.Rating = reviewRequest.Rating;
                    newReview.Email = reviewRequest.Email;
                    newReview.Comment = reviewRequest.Comment;
                    newReview.DateCreated = DateTime.Now;
                    reviewDao.Add(newReview);
                    result.Add(true, "Adding review completed.");
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Add(true, ex.Message);
                    return result;
                }
             
            }
       
        }
    }
}