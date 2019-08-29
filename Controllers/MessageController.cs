
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using livechat.Hubs;
using livechat.Services;
using livechat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private IHubContext<ChatHub> context;
        private readonly IConversationService convService;

        public MessageController(
            IHubContext<ChatHub> context,
            IConversationService convService)
        {
            this.context = context;
            this.convService = convService;
        }

        [HttpGet]
        public async Task<IEnumerable<ConversationVM>> Get()
        {
            ClaimsIdentity claimsIdentity = this.User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            return await this.convService.GetConversations(userId);
        }

        [HttpPost]
        public async Task PostAsync(MessageFormVM message)
        {
            await Task.Delay(0);
            // var aa = UserHandler.ConnectedIds;
            // messages.Add(message);
            // ConversationVM cm = conversations.FirstOrDefault(c => c.Id == message.ConversationId);

            // if (cm != null)
            // {
            //     MessageVM newMessage = new MessageVM()
            //     {
            //         Id = Guid.NewGuid().ToString(),
            //         AuthorId = message.AuthorId,
            //         Content = message.Content,
            //         CreatedAt = DateTime.Now
            //     };

            //     cm.Messages.Add(newMessage);
            //     cm.UpdateAt = DateTime.Now;

            //     await context.Clients.All.SendAsync("ReceiveMessage", 
            //         new { cm.Id, newMessage }
            //     );
            // }

        }

    }
}