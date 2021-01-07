using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ReviewerBuisness
    {
        private readonly ReviewerRepository reviewerRepository;

        public ReviewerBuisness()
        {
            this.reviewerRepository = new ReviewerRepository();
        }
        public List<Reviewer> GetAllReviewers()
        {
            return this.reviewerRepository.GetAllReviewers();
        }

        public bool InsertReviewer(Reviewer r)
        {
            if (this.reviewerRepository.InsertReviewer(r) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
