using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Exam_2016.Models
{
    public class MyHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Hello()
        {
            Clients.All.helloJs("A new user connected.");
            //Clients.All.helloJs(DateTime.Now, "Johannes", new { Name = "wat", Age = 22 });
        }

        public void Send(string name, string msg)
        {
            DateTime Time = DateTime.Now;
            string Name = name;
            string Message = msg;
            Clients.All.message(Time, Name, Message, Context.ConnectionId);
            Chat c = new Models.Chat();
            c.Time = Time;
            c.Name = Name;
            c.Message = Message;
            db.Chats.Add(c);
            db.SaveChanges();
        }
    }
}