using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConfigTool.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("")]
        public string Index()
        {
            return "Хуйня is running";
        }
    }
}