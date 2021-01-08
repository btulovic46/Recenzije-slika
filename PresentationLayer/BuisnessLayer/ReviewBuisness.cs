using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ReviewBuisness
    {
        private readonly ReviewRepository reviewRepository;

        public ReviewBuisness()
        {
            this.reviewRepository = new ReviewRepository();
        }
        public List<Review> GetAllReviewes()
        {
            return this.reviewRepository.GetAllReviews();
        }

        public bool InsertReview(Review r)
        {
            if (this.reviewRepository.InsertReview(r) > 0)
            { 
                return true;
            }
            return false;
        }
    }
}
