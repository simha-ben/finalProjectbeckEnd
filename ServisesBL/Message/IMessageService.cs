using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL
{
  public  interface IMessageService
    {
        List<MessageVM> getAcceptedMessageById(int id);
        List<MessageVM> getSentdMessageById(int id);
        int createNewMessage(MessageVM messageVM);
    }
}
