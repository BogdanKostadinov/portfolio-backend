using System;
using System.Collections.Generic;
using System.Linq;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly List<Feedback> feedbacks = new()
        {
            new Feedback { Id = Guid.NewGuid(), Name = "John", Message = "good" },
            new Feedback { Id = Guid.NewGuid(), Name = "mike", Message = "bad" },
            new Feedback { Id = Guid.NewGuid(), Name = "boko", Message = "average" }
        };

        public List<Feedback> GetFeedbacks()
        {
            return feedbacks;
        }

        public Feedback GetFeedback(Guid id)
        {
            return feedbacks.Where(feedback => feedback.Id == id).SingleOrDefault();
        }

        public void CreateFeedback(Feedback feedback)
        {
            feedbacks.Add(feedback);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            var index = feedbacks.FindIndex(feedbackIndex => feedbackIndex.Id == feedback.Id);

            feedbacks[index] = feedback;
        }
    }
}