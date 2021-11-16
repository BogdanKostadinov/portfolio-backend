using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
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