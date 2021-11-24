using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisesBL;

namespace BackEndAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService messageService;
        public MessageController(IMessageService service)
        {
            this.messageService = service;
        }

        [HttpGet("accepted/{id}")]
        public List<MessageVM> GetAcceptedMessage(int id)
        {
            return messageService.getAcceptedMessageById(id);
        }
        [HttpGet("sent/{id}")]
        public List<MessageVM> GetSentMessage(int id)
        {
            return messageService.getSentdMessageById(id);
        }
        [HttpPost]
        public int CreateNewMessage(MessageVM newMessage)
        {
            return messageService.createNewMessage(newMessage);
        }
    }
}