using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recycler.Waste_Types.Hazardous
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Battaries : ContentPage
	{
		public Battaries()
		{
			InitializeComponent();
		}
		private async void bt_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map(Map.MapMode.Battaries));
		}
	}
}