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
		PageGenerator Generator = new PageGenerator(); //Создание элемента-генератора информации

		public Codes ()
		{
			InitializeComponent (); //Инициализация страницы
        }

		/// <summary>
		/// Обработка нажатия кнопки кода переработки
		/// </summary>
		private async void CodeClicked(object sender, EventArgs e)
		{
			//Пластик
			if (sender == code01 ||
				sender == code02 ||
				sender == code03 ||
				sender == code04 ||
				sender == code05 ||
				sender == code06 ||
				sender == code07)
				//Генерация страницы с информационными полями по пластику
				await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Plastic, Navigation));

            //Бумага
            else if (sender == code20 ||
				sender == code21 ||
				sender == code22 ||
				sender == code23)
                //Генерация страницы с информационными полями по бумаге
                await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Paper, Navigation));

            //Металл
            else if (sender == code40 ||
				sender == code41)
                //Генерация страницы с информационными полями по металлу
                await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Metal, Navigation));

            //Стекло
            else if (sender == code70 ||
				sender == code71 ||
				sender == code72)
                //Генерация страницы с информационными полями по стеклу
                await Navigation.PushAsync(Generator.GeneratePage(PageGenerator.Type.Glass, Navigation));
		}


        /// <summary>
        /// Возврат на главную страницу с текущей
        /// </summary>
        private async void BackHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
        }


		/// <summary>
		/// Переход на страницу с картой с текущей страницы
		/// </summary>
		private async void MapClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Map());
        }


		/// <summary>
		/// Назад - возвращение на предыдущую страницу
		/// </summary>
		private async void BackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
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