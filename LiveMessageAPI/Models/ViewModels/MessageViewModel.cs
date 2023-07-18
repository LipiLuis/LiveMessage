using System;
namespace LiveMessageAPI.Models.ViewModels
{
	public class MessageViewModel
    {
        public int SenderId { get; private set; }
        public int ReceiverId { get; private set; }
        public string Content { get; private set; }

        public MessageViewModel(int senderId, int receiverId, string content)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }
    }
}

