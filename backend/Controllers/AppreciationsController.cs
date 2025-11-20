using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/appreciations")]
    [ApiController]
    public class AppreciationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddAppreciation([FromBody] AppreciationRequest req)
        {
            var members = DataStore.Load();
            var m = members.FirstOrDefault(x => x.Id == req.MemberId);
            if (m == null) return NotFound();

            m.Received.Add(new Appreciation { Message = req.Message });
            DataStore.Save(members);
            return Ok();
        }
    }

    public class AppreciationRequest
    {
        public string MemberId { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
