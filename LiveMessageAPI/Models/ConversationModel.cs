using System;
namespace LiveMessageAPI.Models
{
	public class ConversationModel
	{
        public int Id { get; set; }
        public List<int> ParticipantIds { get; set; }
        public List<MessageModel> Messages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

