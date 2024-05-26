using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recycler.Waste_Types
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _Hazardous : ContentPage
	{
		public _Hazardous ()
		{
			InitializeComponent ();
		}
		private async void bt_bat_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Waste_Types.Hazardous.Battaries());
		}
		private async void bt_chem_Clicked(object sender, EventArgs e)
		{

		}
		private async void bt_electric_Clicked(object sender, EventArgs e)
		{

		}
		private async void bt_pharma_Clicked(object sender, EventArgs e)
		{

		}
	}
}