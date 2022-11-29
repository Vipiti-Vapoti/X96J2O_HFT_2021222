using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace X96J2O_HFT_2021222.Endpoint.Services
{
    public class SignalRHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Diseconmected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
