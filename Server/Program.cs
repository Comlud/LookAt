using System;
using SimpleSockets;
using SimpleSockets.Messaging.Metadata;
using SimpleSockets.Server;

namespace Server
{
	class Program
	{
		private static SimpleSocketTcpListener listener;

		static void Main(string[] args)
		{
			listener = new SimpleSocketTcpListener();
			BindEvents();
			listener.StartListening(2000);

			while (true)
			{
				Console.Write("Type a message to send to all clients: ");
				var message = Console.ReadLine();
				BroadcastMessage(message);
			}
		}

		private static async void BroadcastMessage(string message)
		{
			foreach (var client in listener.GetConnectedClients())
			{
				await listener.SendMessageAsync(client.Value.Id, message);
			}
		}

		private static void BindEvents()
		{
			listener.ServerHasStarted += () =>
			{
				Console.WriteLine("Server has started");
			};

			listener.MessageReceived += (IClientInfo client, string message) =>
			{
				Console.WriteLine($"Client {client.Id}: {message}");
			};

			listener.MessageSubmitted += (IClientInfo client, bool close) =>
			{
				Console.WriteLine($"Sent a message to Client {client.Id}");
			};

			listener.MessageFailed += (IClientInfo client, byte[] messageData, Exception exception) =>
			{
				Console.WriteLine($"Failed to send message to Client {client.Id}");
				Console.WriteLine($"Error: {exception.Message}");
			};

			listener.ClientConnected += (IClientInfo client) =>
			{
				Console.WriteLine($"Client {client.Id} with IPv4 {client.RemoteIPv4} has connected");
			};

			listener.ClientDisconnected += (IClientInfo client, DisconnectReason reason) =>
			{
				int id = client != null ? client.Id : 0;
				Console.WriteLine($"Client {id} has disconnected");
			};

			listener.ServerErrorThrown += (Exception exception) =>
			{
				Console.WriteLine($"Error thrown: {exception.Message}");
				Console.WriteLine($"Stacktrace: {exception.StackTrace}");
			};
		}
	}
}
