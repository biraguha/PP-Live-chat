
using System.Collections.Generic;
using System.Threading.Tasks;
using livechat.Hubs;
using livechat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<ChatHub> context;
        // private static List<MessageVM> messages = new List<MessageVM>();

        public MessageController(IHubContext<ChatHub> context)
        {
            this.context = context;
        }

        // [HttpGet]
        // public async Task<IEnumerable<MessageVM>> Get()
        // {
        //     await Task.Delay(0);
        //     return  messages;
        // }

        [HttpPost]
        public async Task PostAsync(MessageVM message)
        {
            // messages.Add(message);
            await context.Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}