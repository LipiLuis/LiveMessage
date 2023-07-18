using System;
using LiveMessageAPI.Models;
using LiveMessageAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveMessageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public IActionResult SendNotification(NotificationModel notification)
        {
            _notificationService.SendNotification(notification);
            return Ok();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetNotificationsByUserId(int userId)
        {
            var notifications = _notificationService.GetNotificationsByUserId(userId);
            return Ok(notifications);
        }
    }
}

