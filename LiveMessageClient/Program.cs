// See https://aka.ms/new-console-template for more information
using LiveMessageAPI.Models;
using LiveMessageAPI.Models.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;

const string url = "https://localhost:8080/chatHub";


Console.WriteLine("Aplicação iniciada. Pressione qualquer tecla para sair.");

await using var connection = new HubConnectionBuilder()
    .WithUrl(url)
    .Build();

connection.On<MessageViewModel>("ReceiveMessage", message => {
    // Lógica para lidar com a mensagem recebida
    Console.WriteLine($"Nova mensagem recebida: {message.Content}");
});

await connection.StartAsync();

var message = new MessageViewModel(1, 2, "Olá, como você está?");

connection.InvokeAsync("SendMessage", message).Wait();
Console.ReadKey();
connection.StopAsync().Wait();

