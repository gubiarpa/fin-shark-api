using Microsoft.AspNetCore.Mvc;
using net8_training.Interfaces;
using net8_training.Mappers;

namespace net8_training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();

            return Ok(comments.Select(x => x.ToDto()));
        }

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment is null)
                return NotFound();

            return Ok(comment.ToDto());
        }
    }
}