using System;
using LiveMessageAPI.Interfaces;
using LiveMessageAPI.Models;
using LiveMessageAPI.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace LiveMessageAPI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messages;
        private readonly IUserService _users;

        public ChatHub(IMessageService messages, IUserService users)
        {
            _messages = messages;
            _users = users;
        }


        public async Task SendMessage(MessageViewModel model)
        {
            try
            {
                var message = new MessageModel
                {
                    SenderId = model.SenderId,
                    ReceiverId = model.ReceiverId,
                    Content = model.Content,
                    SentAt = DateTime.UtcNow
                };

                _messages.SendMessage(message);

                // Notificar o remetente
                await Clients.Caller.SendAsync("ReceiveMessage", message);

                var _user = _users.GetUserById(model.ReceiverId);

                if (_user is not null)
                {
                    await Clients.All.SendAsync("ReceiveMessage", message);
                    //await Clients.Client("").SendAsync("ReceiveMessage", message);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

