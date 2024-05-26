using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recycler.Waste_Types.Recyclable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Paper : ContentPage
	{
		public Paper ()
		{
			InitializeComponent ();
		}

		private async void bt_map_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map(Map.MapMode.Paper));
        }
    }
}