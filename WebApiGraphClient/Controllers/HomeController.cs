using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace WebApiGraphClient.Controllers
{
    public class HomeController : Controller
    {
        private GraphServiceClient _graphServiceClient;

        public HomeController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        [HttpGet("/getUsers")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _graphServiceClient.Users.Request().WithAppOnly().GetAsync();

            return Ok(users);
        }

        [HttpGet("/getTeam/{teamId}")]
        public async Task<IActionResult> GetTeam(string teamId)
        {
            return Ok(new NotImplementedException());
        }

        [HttpGet("/getChannel/{teamId}/{channelId}")]
        public async Task<IActionResult> GetChannel(string teamId, string channelId)
        {
            return Ok(new NotImplementedException());
        }

        [HttpPost("/sendMessage")]
        public async Task<IActionResult> SendMessage()
        {
            return Ok(new NotImplementedException());
        }
    }
}
