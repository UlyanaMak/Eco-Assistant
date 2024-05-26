using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recycler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectionPage : ContentPage
	{
		public SelectionPage(Button[]bts)
		{
			InitializeComponent();
			foreach(Button bt in bts) 
			{
				bt.Style = Application.Current.Resources["bt_selection"] as Style;
				Content.Children.Add(bt);
			}
		}

		private async void bt_back_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void bt_bottom_home_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
        }

		private async void bt_bottom_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
        }
		private async void bt_user_guide_Clicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path)});
		}
	}
}