using System;
using System.Collections.Generic;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{
    public interface IFeedbackRepository
    {
        Feedback GetFeedback(Guid id);
        List<Feedback> GetFeedbacks();

        void CreateFeedback(Feedback feedback);
    }
}