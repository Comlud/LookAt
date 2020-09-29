using SimpleSockets;
using SimpleSockets.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LookAt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestClient : ContentPage
	{
		private SimpleSocketTcpClient client;

		public TestClient()
		{
			InitializeComponent();

			client = new SimpleSocketTcpClient();
			BindEvents();
			client.StartClient("2.tcp.ngrok.io", 15265); // 127.0.0.1:2000
		}

		private void BindEvents()
		{
			client.ConnectedToServer += (SimpleSocketClient socket) =>
			{
				SetLabelText($"Connected to server on IP {socket.Ip}");
			};

			client.DisconnectedFromServer += (SimpleSocketClient socket) =>
			{
				SetLabelText("Disconnected from server");
			};

			client.MessageReceived += (SimpleSocketClient socket, string message) =>
			{
				SetLabelText($"Server: {message}");
			};

			client.ClientErrorThrown += (SimpleSocketClient socket, Exception exception) =>
			{
				SetLabelText($"Error thrown: {exception.Message}");
				// $"Stacktrace: {exception.StackTrace}{newLine}";
			};
		}

		private void SetLabelText(string text)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				label.Text = text;
			});
		}
	}
}