using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}