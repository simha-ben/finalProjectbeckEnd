using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
   public interface IMessageRepository
    {
        List<Message> getAcceptedMessageById(int id);
        List<Message> getSentMessageById(int id);
        int sentMessage(Message newMessage);
        

    }
}
