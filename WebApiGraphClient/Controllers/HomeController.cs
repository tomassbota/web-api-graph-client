using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Threading.Channels;

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
            var team = await _graphServiceClient.Teams[teamId].Request().WithAppOnly().GetAsync();

            return Ok(team);
        }

        [HttpGet("/getChannel/{teamId}/{channelId}")]
        public async Task<IActionResult> GetChannel(string teamId, string channelId)
        {
            var channel = await _graphServiceClient.Teams[teamId].Channels[channelId].Request().WithAppOnly().GetAsync();

            return Ok(channel);
        }

        [HttpPost("/sendMessage/{teamId}/{channelId}")]
        public async Task<IActionResult> SendMessage(string teamId, string channelId)
        {
            var requestBody = new ChatMessage
            {
                Body = new ItemBody
                {
                    Content = "Hello World",
                },
            };

            var channel = await _graphServiceClient.Teams[teamId].Channels[channelId].Messages.Request().WithAppOnly().AddAsync(requestBody);

            return Ok(new NotImplementedException());
        }
    }
}
