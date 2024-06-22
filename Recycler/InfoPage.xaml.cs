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
	public partial class InfoPage : ContentPage
	{
		Map.MapMode mode;
		public InfoPage(string MainHeader, Article[] articles, Map.MapMode mapMode)
		{
			InitializeComponent ();   //Инициализация страницы
			mode = mapMode;
			this.MainHeader.Text = MainHeader;     //Основной заголовок
			foreach (Article article in articles)  //Вывод информации из массива строк
			{
				Label header = new Label() //Присвоение первому элементу массива типа Label
				{
					Text = article.Header //Поле Text - заголовок
				};
				foreach (string element in article.Elements) //Вывод информационных элементов
				{
					Label information = new Label() { Text = element }; //Обычный текст
					if(article.Options == Article.HorizontalOptions.Left) //Если горизонтально слева
					{
                        information.Style = Application.Current.Resources["textLeft"] as Style; //то присвоение стиля текста слева textLeft
                        header.HorizontalTextAlignment = TextAlignment.Start;         //выравнивание по левому краю
					}
					else if(article.Options == Article.HorizontalOptions.Right)       //Если горизонтально справа
                    {
                        information.Style = Application.Current.Resources["textRight"] as Style;//то присвоение стиля текста справа textRight
                        header.HorizontalTextAlignment = TextAlignment.End;           //выравнивание по правому краю
                    }
					
					Articles.Children.Add(header);
					Articles.Children.Add(information);

					if (article.Button != null) //Если есть доп. кнопка
					{
						article.Button.Style = Application.Current.Resources["knowMore"] as Style; //то ей присваивается соответствующий стиль
						Articles.Children.Add(article.Button); //и выводится
                    }
				}
			}

			Button buttonGoMap = new Button() //Кнопка перехода к карте с информационной страницы
            {
				Style = Application.Current.Resources["mapMainButton"] as Style //Присвоение соответствующего созданного стиля
			};

            buttonGoMap.Clicked += (e, a) => { Navigation.PushAsync(new Map(mapMode)); }; //Событие-переход на страницу с картой

			if (mapMode != Map.MapMode.None) //Если кнопка была нажата (не null)
			{ 
				Articles.Children.Add(new Label() { Style = new Style(typeof(Label)) { Setters = { new Setter() { Property = Label.MarginProperty, Value = new Thickness(0, 10, 0, 0) } } }, Text = "Куда сдавать в городе Пермь?", HorizontalTextAlignment = TextAlignment.Center }); 
				Articles.Children.Add(buttonGoMap); 
				
			}
		}
		public InfoPage()
		{
			InitializeComponent(); //Инициализация страницы вцелом
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
			await Navigation.PushAsync(new Map(mode));
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