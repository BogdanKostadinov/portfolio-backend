using System;

namespace Portfolio.Api.DTOs
{
    public class FeedbackDTO
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public string Message { get; set; }

    }
}