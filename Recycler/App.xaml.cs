using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Recycler
{
	public partial class App : Application
	{
		public const string AppName = "Eco Assistant";
		public static string Path;
		public App(string path)
		{
			InitializeComponent();
			NavigationPage page = new NavigationPage(new MainPage());
			MainPage = page;
			Path= path;
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
