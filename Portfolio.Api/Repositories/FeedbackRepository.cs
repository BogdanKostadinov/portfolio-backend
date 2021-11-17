using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Api.Models;

namespace Portfolio.Api.Repositories
{

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly List<Feedback> feedbacks = new()
        {
            new Feedback { Id = Guid.NewGuid(), Name = "John", Message = "good" },
            new Feedback { Id = Guid.NewGuid(), Name = "mike", Message = "bad" },
            new Feedback { Id = Guid.NewGuid(), Name = "boko", Message = "average" }
        };

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await Task.FromResult(feedbacks);
        }

        public async Task<Feedback> GetFeedbackAsync(Guid id)
        {
            var result = feedbacks.Where(feedback => feedback.Id == id).SingleOrDefault();
            return await Task.FromResult(result);
        }

        public async Task CreateFeedbackAsync(Feedback feedback)
        {
            feedbacks.Add(feedback);
            await Task.CompletedTask;
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            var index = feedbacks.FindIndex(feedbackIndex => feedbackIndex.Id == feedback.Id);

            feedbacks[index] = feedback;

            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            
            var index = feedbacks.FindIndex(feedbackIndex => feedbackIndex.Id == id);           

            feedbacks.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}