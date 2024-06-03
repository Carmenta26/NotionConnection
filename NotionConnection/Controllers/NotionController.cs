using NotionConnection.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NotionConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotionController : ControllerBase
    {
        private readonly NotionService _notionService;

        public NotionController(NotionService notionService)
        {
            _notionService = notionService;
        }

        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment([FromBody] NotionCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _notionService.AddCommentAsync(request);
            return Ok();
        }
    }
}
