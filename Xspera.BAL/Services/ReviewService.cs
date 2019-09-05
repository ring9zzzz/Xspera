using System;
using System.Collections.Generic;
using System.Text;
using Xspera.DAL.Entities;

namespace Xspera.BAL.Services
{
    public interface IReviewService
    {
        bool AddingReview(Review review);
    }
    public class ReviewService : IReviewService
    {
        public bool AddingReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
