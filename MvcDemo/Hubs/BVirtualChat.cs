using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Hubs
{
    public class BVirtualChat : Hub
    {
        public void GetOnlineUserList()
        {
            Clients.All.refreshOnlineUserList(MvcDemo.Models.UserLogin.loginDb);
        }

        public void SendChatMessage(string message, string to, string from)
        {
            Clients.All.getChatMessage(message, to, from);
        }
    }
}