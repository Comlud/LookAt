﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LookAt
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new TestClient();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
