using AIAssistant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly IErrorAnalyzer _service;

        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("analyze-error")]
        public async Task<IActionResult> AnalyzeError([FromBody] ErrorRequest request)
        {
            var result = await _aiService.AnalyzeError(request.Message);

            return Ok(result);
        }
        [HttpPost("hello")]
        public async Task<IActionResult> Hello([FromBody] ErrorRequest request)
        {

            return Ok("hello");
        }
    }
}
