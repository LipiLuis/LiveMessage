using System;
using LiveMessageAPI.Models;

namespace LiveMessageAPI.Interfaces
{
	public interface IMessageService
	{
        void SendMessage(MessageModel message);
        List<MessageModel> GetMessagesBySenderId(int senderId);
        List<MessageModel> GetMessagesByReceiverId(int receiverId);
    }
}

