using System;
using LiveMessageAPI.Hubs;
using LiveMessageAPI.Interfaces;
using LiveMessageAPI.Models;
using LiveMessageAPI.Models.ViewModels;
using LiveMessageAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LiveMessageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController( IMessageService messageService)
        {
            _messageService = messageService;
        }



        [HttpGet("sender/{senderId}")]
        public IActionResult GetMessagesBySenderId(int senderId)
        {
            var messages = _messageService.GetMessagesBySenderId(senderId);
            return Ok(messages);
        }

        [HttpGet("receiver/{receiverId}")]
        public IActionResult GetMessagesByReceiverId(int receiverId)
        {
            var messages = _messageService.GetMessagesByReceiverId(receiverId);
            return Ok(messages);
        }
    }
}

