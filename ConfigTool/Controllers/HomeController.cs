using Microsoft.AspNetCore.Mvc;

namespace ConfigTool.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public string Index()
        {
            return "Хуйня is running";
        }
    }
}