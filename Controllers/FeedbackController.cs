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

        public FeedbackController(IFeedbackRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<FeedbackDTO> GetFeedbacks()
        {
            var feedbacks = repository.GetFeedbacks().Select(feedback => feedback.asDTO());

            return feedbacks;
        }

        [HttpGet("{id}")]
        public ActionResult<FeedbackDTO> GetFeedback(int id)
        {
            var item = repository.GetFeedback(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.asDTO();
        }
    }
}
