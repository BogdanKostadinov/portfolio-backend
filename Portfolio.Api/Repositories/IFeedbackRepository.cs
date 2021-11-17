using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Api.Models;

namespace Portfolio.Api.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Feedback> GetFeedbackAsync(Guid id);

        Task<List<Feedback>> GetFeedbacksAsync();

        Task CreateFeedbackAsync(Feedback feedback);

        Task UpdateFeedbackAsync(Feedback feedback);

        Task DeleteItemAsync(Guid id);
    }
}