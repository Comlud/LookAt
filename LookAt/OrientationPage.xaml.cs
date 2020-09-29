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
				float x = orientation.X;
				float y = orientation.Y;
				float z = orientation.Z;

				orientationLabel.Text = $"Orientation X: {x:F2}, Y: {y:F2}, Z: {z:F2}";
			};

			OrientationSensor.Start(SensorSpeed.Fastest);
		}
	}
}