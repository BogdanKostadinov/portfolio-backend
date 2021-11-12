using System.Collections.Generic;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{
        public interface IFeedbackRepository
    {
        Feedback GetFeedback(int id);
        List<Feedback> GetFeedbacks();
    }
}