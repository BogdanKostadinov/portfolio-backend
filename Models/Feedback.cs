using System;
using System.ComponentModel.DataAnnotations;

namespace portfolio_backend.Models
{
    public class Feedback
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        [Required]
        public string Message { get; set; }

    }
}