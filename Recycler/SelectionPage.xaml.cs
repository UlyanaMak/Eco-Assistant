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
		public SelectionPage(Button[]buttons)
		{
			InitializeComponent();
			//Вывод кнопок выбора типа мусора
			foreach(Button button in buttons) 
			{
                button.Style = Application.Current.Resources["wasteType"] as Style; //Присвоение каждой кнопки стиля wasteType
                Content.Children.Add(button);
			}
		}


        /// <summary>
        /// Назад - возвращение на предыдущую страницу
        /// </summary>
        private async void BackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
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
        /// Открытие файла с руководством пользователя
        /// </summary>
        private async void UserGuideClicked(object sender, EventArgs e)
		{
			await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(App.Path)});
		}
	}
}