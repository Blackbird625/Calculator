using Xamarin.Forms;

namespace Calculator
{
	public partial class App : Application
	{
		public static readonly char DecimalSeparator = '-';

		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
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
