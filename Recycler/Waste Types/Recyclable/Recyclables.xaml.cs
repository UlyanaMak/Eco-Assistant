using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Recycler;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recycler.Waste_Types.Recyclable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Recyclables : ContentPage
	{
		public Recyclables()
		{
			InitializeComponent();
		}

		private async void bt_paper_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Paper());
		}

		private async void bt_glass_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Glass());
		}

		private async void bt_plastic_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Plastic());
		}

		private async void bt_metal_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Metal());
		}
	}
}