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
        /// <summary>Addings the review.</summary>
        /// <param name="reviewRequest">The review request.</param>
        /// <returns></returns>
        Dictionary<bool, string> AddingReview(ReviewRequest reviewRequest);
    }

    public class ReviewService : IReviewService
    {
        private IRepository _repository;

        public ReviewService(IRepository myRepository)
        {
            this._repository = myRepository;
        }

        /// <summary>Addings the review.</summary>
        /// <param name="reviewRequest">The review request.</param>
        /// <returns></returns>
        public Dictionary<bool, string> AddingReview(ReviewRequest reviewRequest)
        {
            var reviewDao = this._repository.GetDao<Review>();
            var trans = reviewDao.BeginTransaction();
            var result = new Dictionary<bool, string>();
            try
            {
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
                result.Add(false, ex.Message);
                return result;
            }
        }
    }
}