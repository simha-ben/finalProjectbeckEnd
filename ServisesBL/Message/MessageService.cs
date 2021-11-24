using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Common;
using Repositories.Models;
using Repositories.Repositories;

namespace ServisesBL
{
   public class MessageService : IMessageService
    {
        IMessageRepository messageRepo;
        IUserRepository userRepo;
        IMapper mapper;
        public MessageService(IMessageRepository messageRepo,IMapper mapper, IUserRepository userRepo)
        {
            this.mapper = mapper;
            this.messageRepo = messageRepo;
            this.userRepo = userRepo;
        }

        public int createNewMessage(MessageVM messageVM)
        {
                Message newM=(mapper.Map<Message>(messageVM));
            return messageRepo.sentMessage(newM);
        }

        public List<MessageVM> getAcceptedMessageById(int id)
        {
            List<MessageVM> acceptefMessage = new List<MessageVM>();
            List<Message> messages = messageRepo.getAcceptedMessageById(id);
            foreach (var item in messages)
            {
                MessageVM m=(mapper.Map<MessageVM>(item));
                m.FromUserName = userRepo.getUserById(m.FromUser);
                acceptefMessage.Add(m);
            }
            return acceptefMessage;

        }

        public List<MessageVM> getSentdMessageById(int id)
        {
            List<MessageVM> sentfMessage = new List<MessageVM>();
            List<Message> messages = messageRepo.getSentMessageById(id);
            foreach (var item in messages)
            {
                MessageVM m = (mapper.Map<MessageVM>(item));
                m.ToUserName = userRepo.getUserById(id);
                sentfMessage.Add(m);
            }
            return sentfMessage;
        }
    }
}
