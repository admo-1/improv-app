using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("self-evaluation")]
    public class SelfEvaluationController : ControllerBase
    {
        private readonly ISelfEvaluationService _service;

        public SelfEvaluationController(ISelfEvaluationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] SelfEvaluationRequest request)
        {
            var selfEval = await _service.UpsertAsync(request);
            return Ok(selfEval);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var selfEval = await _service.GetByUserIdAsync(userId);
            if (selfEval == null) return NotFound();
            return Ok(selfEval);
        }
    }
