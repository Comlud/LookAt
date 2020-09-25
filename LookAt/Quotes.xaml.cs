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
	public partial class Quotes : ContentPage
	{
		List<String> quotes = new List<String>();
		int currentQuoteIndex = 0;

		public Quotes()
		{
			InitializeComponent();

			quotes.Add("Look deep into nature, and then you will understand everything better.");
			quotes.Add("Life is like riding a bicycle. To keep your balance, you must keep moving.");
			quotes.Add("You can't blame gravity for falling in love.");

			UpdateQuote();
		}

		private void OnNextClicked(object sender, EventArgs e)
		{
			UpdateQuote();
		}

		private void UpdateQuote()
		{
			quote.Text = quotes[currentQuoteIndex];

			// Loop index.
			if (++currentQuoteIndex % quotes.Count == 0)
				currentQuoteIndex = 0;
		}
	}
}