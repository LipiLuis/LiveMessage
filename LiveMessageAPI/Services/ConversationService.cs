using System;
using LiveMessageAPI.Data;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Services
{
    public class ConversationService
    {
        private readonly ApplicationDbContext _dbContext;

        public ConversationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateConversation(ConversationModel conversation)
        {
            _dbContext.Conversations.Add(conversation);
            _dbContext.SaveChanges();
        }

        public ConversationModel GetConversationById(int id)
        {
            return _dbContext.Conversations.FirstOrDefault(c => c.Id == id);
        }

        public List<ConversationModel> GetAllConversations()
        {
            return _dbContext.Conversations.ToList();
        }
    }
}

