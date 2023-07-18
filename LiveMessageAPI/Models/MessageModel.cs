using System;
namespace LiveMessageAPI.Models
{
	public class MessageModel
	{
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public virtual UserModel Receiver { get; set; }
        public virtual UserModel Sender { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}

