using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageAController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
