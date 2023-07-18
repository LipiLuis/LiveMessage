using System;
using LiveMessageAPI.Models;
using LiveMessageAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveMessageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly ConversationService _conversationService;

        public ConversationController(ConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpPost]
        public IActionResult CreateConversation(ConversationModel conversation)
        {
            _conversationService.CreateConversation(conversation);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetConversationById(int id)
        {
            var conversation = _conversationService.GetConversationById(id);
            if (conversation == null)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        [HttpGet]
        public IActionResult GetAllConversations()
        {
            var conversations = _conversationService.GetAllConversations();
            return Ok(conversations);
        }
    }
}

