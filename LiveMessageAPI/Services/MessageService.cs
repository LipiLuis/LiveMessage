using System;
using LiveMessageAPI.Data;
using LiveMessageAPI.Interfaces;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SendMessage(MessageModel message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        public List<MessageModel> GetMessagesBySenderId(int senderId)
        {
            return _dbContext.Messages.Where(m => m.SenderId == senderId).ToList();
        }

        public List<MessageModel> GetMessagesByReceiverId(int receiverId)
        {
            return _dbContext.Messages.Where(m => m.ReceiverId == receiverId).ToList();
        }
    }
}

