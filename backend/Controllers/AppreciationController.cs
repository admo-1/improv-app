using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("appreciations")]
    [ApiController]
    public class AppreciationController : ControllerBase
    {
        private readonly IAppreciationService _service;

        public AppreciationController(IAppreciationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppreciationRequest request)
        {
            var appreciation = await _service.CreateAsync(request);
            return Ok(appreciation);
        }

        [HttpGet("received/{userId}")]
        public async Task<IActionResult> GetReceived(int userId)
        {
            var list = await _service.GetReceivedByUserAsync(userId);
            return Ok(list);
        }

        [HttpGet("sent/{userId}")]
        public async Task<IActionResult> GetSent(int userId)
        {
            var list = await _service.GetSentByUserAsync(userId);
            return Ok(list);
        }
    }
