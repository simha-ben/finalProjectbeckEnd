using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
   public class MessageRepository : IMessageRepository
    {
        easyPlan context;
        public MessageRepository(easyPlan context)
        {
            this.context = context;
        }
        public List<Message> getAcceptedMessageById(int id)
        {
            List<Message> AcceptedMessage = new List<Message>();
            foreach (var item in context.Message)
            {
                if (item.ToUser == id)
                {
                    AcceptedMessage.Add(item);
                }
            }
            //AcceptedMessage= context.Users.Where(u => u.Id == id).FirstOrDefault().MessageFromUserNavigation.ToList();
            return AcceptedMessage;
        }

        public int sentMessage(Message newMessage)
        {
            context.Message.Add(newMessage);
            int isOK = -99;
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex) { }

            return isOK;
        }

        List<Message> IMessageRepository.getSentMessageById(int id)
        {
            List<Message> sentMessage = new List<Message>();
            foreach (var item in context.Message)
            {
                if (item.FromUser == id)
                {
                    sentMessage.Add(item);
                }
            }
            //sentMessage= context.Users.Where(u => u.Id == id).FirstOrDefault().MessageToUserNavigation.ToList();
            return sentMessage;
        }
    }
}
