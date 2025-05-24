using Microsoft.AspNetCore.Mvc;
using Practica3_JeanEstrada.Data;
using Practica3_JeanEstrada.Models;
using System.Linq;

namespace Practica3_JeanEstrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var feedbacks = _context.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Feedback feedback)
        {
            // Validar si ya existe un feedback para ese postId
            var existe = _context.Feedbacks.Any(f => f.PostId == feedback.PostId);
            if (existe)
            {
                return BadRequest("Ya se envió feedback para este post.");
            }

            feedback.Fecha = DateTime.Now;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();

            return Ok(feedback);
        }
    }
}
