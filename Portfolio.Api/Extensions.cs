using System;
using Portfolio.Api.DTOs;
using Portfolio.Api.Models;

namespace Portfolio.Api
{
    public static class Extensions
    {
        public static FeedbackDTO asDTO(this Feedback feedback)
        {
            return new FeedbackDTO
            {
                Id = feedback.Id,
                Message = feedback.Message,
                Name = feedback.Name
            };
        }
    }
}