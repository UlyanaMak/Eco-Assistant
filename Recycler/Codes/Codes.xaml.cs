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
	public partial class Codes : ContentPage
	{
		PageGenerator Generator = new PageGenerator();
		public Codes ()
		{
			InitializeComponent ();
		}

		private async void bt_code_Clicked(object sender, EventArgs e)
		{
			if (sender == bt_code_01 ||
				sender == bt_code_02 ||
				sender == bt_code_03 ||
				sender == bt_code_04 ||
				sender == bt_code_05 ||
				sender == bt_code_06 ||
				sender == bt_code_07)
				await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Plastic, Navigation));

			else if(sender == bt_code_20 ||
				sender == bt_code_21 ||
				sender == bt_code_22 ||
				sender == bt_code_23) await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Paper, Navigation));

			else if (sender == bt_code_40 ||
				sender == bt_code_41) await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Metal, Navigation));

			else if(sender == bt_code_70 ||
				sender == bt_code_71 ||
				sender == bt_code_72) await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Glass, Navigation));
		}

		private async void bt_bottom_home_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
        }

		private async void bt_bottom_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
        }

		private async void bt_back_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
		private async void bt_user_guide_Clicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path) });
		}
	}
}