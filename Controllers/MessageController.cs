
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livechat.Hubs;
using livechat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<ChatHub> context;

        private List<MessageVM> msg1;
        private List<MessageVM> msg2;
        private List<MessageVM> msg3;
        private List<ConversationVM> conversations;

        public MessageController(IHubContext<ChatHub> context)
        {
            msg1 = new List<MessageVM>()
            {
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "aaa1", CreatedAt = new DateTime(2019, 5, 4, 9, 0, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "bbb1", CreatedAt = new DateTime(2019, 5, 4, 11, 20, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "ccc3", CreatedAt = new DateTime(2019, 5, 4, 15, 10, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "ddd3", CreatedAt = new DateTime(2019, 5, 4, 15, 15, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "eee3", CreatedAt = new DateTime(2019, 5, 4, 18, 45, 0) }
            };

            msg2 = new List<MessageVM>()
            {
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "aaa2", CreatedAt = new DateTime(2019, 6, 10, 9, 10, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "bbb3", CreatedAt = new DateTime(2019, 6, 11, 8, 10, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "ccc3", CreatedAt = new DateTime(2019, 6, 12, 15, 30, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "ddd3", CreatedAt = new DateTime(2019, 6, 15, 15, 15, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "eee3", CreatedAt = new DateTime(2019, 6, 18, 22, 30, 0) }
            };

            msg3 = new List<MessageVM>()
            {
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "aaa3", CreatedAt = new DateTime(2019, 7, 1, 10, 10, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "bbb3", CreatedAt = new DateTime(2019, 7, 1, 10, 20, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "ccc3", CreatedAt = new DateTime(2019, 7, 1, 10, 22, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 0, Content = "ddd3", CreatedAt = new DateTime(2019, 7, 1, 10, 50, 0) },
                new MessageVM() { Id = Guid.NewGuid().ToString(), Author = 1, Content = "eee3", CreatedAt = new DateTime(2019, 7, 5, 15, 30, 0) }
            };

            conversations = new List<ConversationVM>()
            {
                new ConversationVM() { Id = 1, Author = "Admin", Recipient = "Ben", Messages = msg1 },
                new ConversationVM() { Id = 2, Author = "Admin", Recipient = "Boris", Messages = msg2 },
                new ConversationVM() { Id = 3, Author = "Admin", Recipient = "Bob", Messages = msg3 },
                new ConversationVM() { Id = 4, Author = "Ben", Recipient = "Admin", Messages = msg2 },
                new ConversationVM() { Id = 5, Author = "Ben", Recipient = "Bob", Messages = msg3 }
            };

            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ConversationVM>> Get()
        {
            await Task.Delay(0);
            return conversations;
        }

        [HttpPost]
        public async Task PostAsync(MessageFormVM message)
        {
            // var aa = UserHandler.ConnectedIds;
            // messages.Add(message);
            ConversationVM cm = conversations.FirstOrDefault(c => c.Id == message.Conversation);

            if (cm != null)
            {
                MessageVM newMessage = new MessageVM()
                {
                    Id = Guid.NewGuid().ToString(),
                    Author = message.Author,
                    Content = message.Content,
                    CreatedAt = DateTime.Now
                };

                cm.Messages.Add(newMessage);
                cm.UpdateAt = DateTime.Now;

                await context.Clients.All.SendAsync("ReceiveMessage", 
                    new { cm.Id, newMessage }
                );
            }

        }

    }
}