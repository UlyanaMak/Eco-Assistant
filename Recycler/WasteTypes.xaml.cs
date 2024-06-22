using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Recycler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WasteTypes : ContentPage
	{
		PageGenerator Generator = new PageGenerator();
		public WasteTypes()
		{
			InitializeComponent(); //Инициализация страницы
		}


		/// <summary>
		/// Нажатие кнопки "Перерабатываемые отходы"
		/// </summary>
		private async  void RecyclableClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Recyclable, Navigation));
		}


        /// <summary>
        /// Нажатие кнопки "Опасные отходы"
        /// </summary>
        private async void HazardousClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Hazardous, Navigation));
		}


        /// <summary>
        /// Нажатие кнопки "Органические отходы"
        /// </summary>
        private async void OrganicClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Organic, Navigation));
		}


        /// <summary>
        /// Назад - возвращение на предыдущую страницу
        /// </summary>
        private async void backClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}


        
        /// <summary>
        /// Возврат на главную страницу с текущей
        /// </summary>
        private async void backHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
		}


        /// <summary>
        /// Переход на страницу с картой с текущей страницы
        /// </summary>
        private async void mapClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Map());
        }


        /// <summary>
        /// Открытие файла с руководством пользователя
        /// </summary>
        private async void userGuideClicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path) });
		}
	}
}