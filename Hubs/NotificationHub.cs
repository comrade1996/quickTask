using quickTask.Contracts;
using quickTask.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Hubs
{
    public class NotificationHub : Hub
    {
        //public async Task SendMessage(string title, string user, string message)
        //{
        //    await Clients.All.SendMessageToClient(title, user, message);
        //}

        public async Task SendMessage(string user, string message)
        {
            Debug.WriteLine("teesssst");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
       
    }
}
