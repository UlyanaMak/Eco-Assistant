using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace Recycler
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Xamarin.Forms.NavigationPage.SetTitleIconImageSource(this, ImageSource.FromResource("recycle_logo.png"));
		}

		private async void bt_wasteType_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new WasteTypes());
		}

		private async void bt_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
		}

		private async void bt_codes_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Codes());
		}

		private void bt_bottom_home_Clicked(object sender, EventArgs e)
		{

        }

		private async void bt_bottom_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
        }

		private async void bt_user_guide_Clicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path) });
		}
	}
}
