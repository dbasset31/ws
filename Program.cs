using System;
using System.Net;
using System.Net.WebSockets;

class Program
{
    static void Main(string[] args)
    {
        // Créez une instance de WebSocketServer.
        WebSocketServer server = new WebSocketServer();

        // Définissez l'adresse IP et le port sur lesquels le serveur écoute.
        server.ListenAsync(IPAddress.Any, 8080);

        // Attendez qu'un client se connecte.
        WebSocket socket = await server.AcceptAsync();

        // Envoyez un message au client.
        socket.SendAsync("Bienvenue sur le serveur !");

        // Attendez un message du client.
        string message = await socket.ReceiveAsync<string>();

        // Envoyez une réponse au client.
        socket.SendAsync(message);

        // Fermez la connexion.
        socket.CloseAsync();
    }
}
