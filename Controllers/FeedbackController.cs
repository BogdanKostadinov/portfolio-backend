using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using portfolio_backend.Models;
using portfolio_backend.Repositories;

namespace portfolio_backend.Controllers
{

    [ApiController]
    [Route("feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackRepository repository;

        public FeedbackController()
        {
            repository = new FeedbackRepository();
        }
        
        [HttpGet]
        public List<Feedback> GetFeedbacks(){
            return repository.GetFeedbacks();
        }

        [HttpGet("{id}")]
        public ActionResult<Feedback> GetFeedback(int id)
        {
            var list = repository.GetFeedback(id);
         
            if (list is null)
            {
                return NotFound();
            }

            return repository.GetFeedback(id);
        }
    }
}
