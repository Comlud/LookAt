using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace LookAt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrientationPage : ContentPage
	{
		public OrientationPage()
		{
			InitializeComponent();

			// On phone orientation update.
			OrientationSensor.ReadingChanged += (object sender, OrientationSensorChangedEventArgs e) =>
			{
				var orientation = e.Reading.Orientation;

				orientationLabel.Text = $"Orientation X: {orientation.X:F2}, Y: {orientation.Y:F2}, Z: {orientation.Z:F2}, W: {orientation.W:F2}";
			};

			OrientationSensor.Start(SensorSpeed.Fastest);
		}
	}
}