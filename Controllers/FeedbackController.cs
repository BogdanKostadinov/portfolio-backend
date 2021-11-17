using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using portfolio_backend.DTOs;
using portfolio_backend.Models;
using portfolio_backend.Repositories;

namespace portfolio_backend.Controllers
{

    [ApiController]
    [Route("feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository repository;
        private readonly ILogger<FeedbackController> logger;

        public FeedbackController(IFeedbackRepository repository, ILogger<FeedbackController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedbackDTO>> GetFeedbacksAsync()
        {
            var feedbacks = (await repository.GetFeedbacksAsync())
                            .Select(feedback => feedback.asDTO());

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {feedbacks.Count()} feedbacks");

            return feedbacks;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedbackAsync(Guid id)
        {
            var item = await repository.GetFeedbackAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.asDTO();
        }

        //POST /feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackDTO>> CreateFeedbackAsync(CreateFeedbackDTO feedbackDTO)
        {
            Feedback feedback = new()
            {
                Message = feedbackDTO.Message,
                Name = feedbackDTO.Name
            };

            await repository.CreateFeedbackAsync(feedback);

            return CreatedAtAction(nameof(GetFeedbackAsync), new {id = feedback.Id}, feedback.asDTO());
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedbackAsync(Guid id, UpdateFeedbackDTO feedbackDTO)
        {
            var existingFeedback = await repository.GetFeedbackAsync(id);

            if (existingFeedback is null)
            {
                return NotFound();
            }

            Feedback updatedFeedback = existingFeedback with {
                Name = feedbackDTO.Name,
                Message = feedbackDTO.Message
            };

            await repository.UpdateFeedbackAsync(updatedFeedback);

            return NoContent();
        }

        //DELETE /feedback/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingFeedback = await repository.GetFeedbackAsync(id);

            if (existingFeedback is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
