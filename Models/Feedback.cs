using System;
using System.ComponentModel.DataAnnotations;

namespace portfolio_backend.Models
{
    public record Feedback
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        [Required]
        public string Message { get; set; }

    }
}