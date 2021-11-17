using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Models
{
    public record Feedback
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        [Required]
        public string Message { get; set; }

    }
}