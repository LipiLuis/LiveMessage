using System;
using LiveMessageAPI.Data;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SendNotification(NotificationModel notification)
        {
            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();
        }

        public List<NotificationModel> GetNotificationsByUserId(int userId)
        {
            return _dbContext.Notifications.Where(n => n.UserId == userId).ToList();
        }
    }
}

