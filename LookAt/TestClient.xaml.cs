using SimpleSockets;
using SimpleSockets.Client;
using System;

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
			client = new SimpleSocketTcpClient();
			BindEvents();

			InitializeComponent();
		}

		private void BindEvents()
		{
			client.ConnectedToServer += (SimpleSocketClient socket) =>
			{
				SetLabelText("Connected to server");
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

		private void buttonClicked(object sender, EventArgs e)
		{
			client.StartClient(ipEntry.Text, Int32.Parse(portEntry.Text));
		}
	}
}