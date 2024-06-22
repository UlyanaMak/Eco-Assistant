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
			InitializeComponent(); //Инициализация страницы
			Xamarin.Forms.NavigationPage.SetTitleIconImageSource(this, ImageSource.FromResource("recycle_logo.png"));
		}


		/// <summary>
		/// Переход на меню "Виды отходов"
		/// </summary>
		private async void WasteTypeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new WasteTypes());
		}

		
		/// <summary>
		/// Переход на меню "Коды переработки"
		/// </summary>
		private async void CodesClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Codes());
		}


		/// <summary>
		/// Переход на карту с главной страницы
		/// </summary>
        private async void MainMapClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Map());
        }


        /// <summary>
        /// Пустой метод перехода на главную страницу, так как уже на главной
        /// </summary>
        private void BackHomeClicked(object sender, EventArgs e)
		{

        }


        /// <summary>
        /// Переход на страницу с картой с текущей страницы
        /// </summary>
        private async void MapClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
        }


        /// <summary>
        /// Открытие файла с руководством пользователя
        /// </summary>
        private async void UserGuideClicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path) });
		}
	}
}
