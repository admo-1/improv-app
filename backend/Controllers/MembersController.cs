using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMembers()
        {
            return Ok(DataStore.Load());
        }

        [HttpGet("{id}")]
        public IActionResult GetMember(string id)
        {
            var m = DataStore.Load().FirstOrDefault(x => x.Id == id);
            if (m == null) return NotFound();
            return Ok(m);
        }

        [HttpPost("highlight")]
        public IActionResult UpdateHighlight([FromBody] Member update)
        {
            var members = DataStore.Load();
            var m = members.FirstOrDefault(x => x.Id == update.Id);
            if (m == null) return NotFound();

            m.HighlightMessage = update.HighlightMessage;
            DataStore.Save(members);
            return Ok();
        }
    }
}
