using System;
using portfolio_backend.DTOs;
using portfolio_backend.Models;

namespace portfolio_backend
{
    public static class Extensions
    {
        public static FeedbackDTO asDTO(this Feedback feedback)
        {
            return new FeedbackDTO
            {
                Id = Guid.NewGuid(),
                Message = feedback.Message,
                Name = feedback.Name
            };
        }
    }
}