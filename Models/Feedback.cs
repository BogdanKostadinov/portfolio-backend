using System;

namespace portfolio_backend.Models
{
    public class Feedback
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public string Message { get; set; }

    }
}