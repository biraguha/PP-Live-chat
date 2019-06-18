using System.Threading.Tasks;
using livechat.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageVM message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}