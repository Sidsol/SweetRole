using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.AspNetCore.SignalR.Hubs;

namespace SweetRole.Hubs
{
    //[HubMethodName("SingleChatHub")]
    public class ChatHub : Hub
    {
        //public async Task NewMessage(string username, string message)
        //{
        //    await Clients.All.SendAsync("messageReceived", username, message);
        //}
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
