using System.Collections.Generic;
using System.Linq;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly List<Feedback> feedbacks = new()
        {
            new Feedback { Id = 1, Name = "John", Message = "good" },
            new Feedback { Id = 2, Name = "mike", Message = "bad" },
            new Feedback { Id = 3, Name = "boko", Message = "average" }
        };

        public List<Feedback> GetFeedbacks()
        {
            return feedbacks;
        }

        public Feedback GetFeedback(int id)
        {

            return feedbacks.Where(feedback => feedback.Id == id).SingleOrDefault();
        }
    }
}