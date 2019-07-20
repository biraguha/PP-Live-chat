using System;
using System.Threading.Tasks;
using livechat.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace livechat.Hubs
{
    public class ChatHub : Hub
    {
        // public async Task SendMessage(MessageVM message)
        // {
        //     await Clients.All.SendAsync("ReceiveMessage", message);
        // }

        public override Task OnConnectedAsync()
        {
            System.Console.WriteLine(Context.ConnectionId);
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}