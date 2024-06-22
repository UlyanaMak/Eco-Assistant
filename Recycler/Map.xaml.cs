using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace Recycler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class Map : ContentPage
	{
		/// <summary>
		/// Режимы обозначений на карте
		/// </summary>
		public enum MapMode
		{
			None,      //нет
			Paper,     //бумага
			Metal,     //металл
			Glass,     //стекло
			Plastic,   //пластик
			Battaries, //батарейки
			Chem,      //химия
			Pharma,    //фарма
			Electro,   //электро
			Food,      //пищевые
			Garden,    //садовые
			Animal     //животные
		};

		//Начальный режим - нет (при открытии карты)
		MapMode CurrentMode = MapMode.None;

		//Список пинов для обозначений на карте (пластик)
		List<Pin> PlasticPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Экодом Разделяю сердцем",
				Address = "бул. Гагарина, 65/1",
				Position = new Position(58.005224, 56.289051),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторпроект",
				Address = "Рязанская ул., 101",
				Position= new Position(57.970401, 56.180906),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Эконис",
				Address = "ул. Куйбышева, 128А",
				Position= new Position(57.957415, 56.248191),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторая жизнь",
				Address = "Ижевская ул., 29А",
				Position= new Position(57.984108, 56.275414),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Аверспак",
				Address = "ул. Клары Цеткин, 14",
				Position = new Position(57.987635, 56.240165),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "ТКО-Прикамье",
				Address = "1-я Бахаревская ул., 53, корп. 4",
				Position = new Position(57.952086, 56.238480),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (бумага)
        List<Pin> PaperPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Аверспак",
				Address = "ул. Клары Цеткин, 14",
				Position = new Position(57.987635, 56.240165),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторая жизнь",
				Address = "Ижевская ул., 29А",
				Position = new Position(57.984108, 56.275414),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Перммакулатура жизнь",
				Address = "ул. Дзержинского, 53",
				Position = new Position(58.006800, 56.162283),
				Type = PinType.Place
			}
		};

        //Список пинов для обозначений на карте (металл)
        List<Pin> MetalPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "А-кат Приём катализаторов",
				Address = "ул. Яблочкова, 9",
				Position = new Position(57.970391, 56.231662),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Лига",
				Address = "Хлебозаводская ул., 19А/3",
				Position = new Position(57.970619, 56.254718),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Алмеко",
				Address = "ул. Лодыгина, 9",
				Position = new Position(57.966985, 56.237903),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Метапром",
				Address = "ул. Героев Хасана, 66/1",
				Position = new Position(57.964009, 56.255998),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Танталмет",
				Address = "ул. Героев Хасана, 74, корп. 2",
				Position = new Position(57.960768, 56.264309),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (стекло)
        List<Pin> GlassPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Прием стеклотары",
				Address = "Фоминская ул., 53",
				Position = new Position(58.008241, 56.070401),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема стеклотары",
				Address = "ул. Писарева, 13",
				Position = new Position(58.105759, 56.304768),
				Type = PinType.Place
			}
		};

        //Список пинов для обозначений на карте (батарейки)
        List<Pin> BattariesPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "Витимская ул., 17А",
				Position = new Position(58.040671, 55.893869),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "трасса Пермь – Краснокамск, 71/1",
				Position = new Position(58.053403, 55.852358),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "Витимская ул., 17А",
				Position = new Position(58.048354, 56.062356),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "Подлесная ул., 43Б",
				Position = new Position(57.996483, 56.166198),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "Братская ул., 137",
				Position = new Position(57.976005, 56.315113),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Пункт приема батареек",
				Address = "ул. Писарева, 2В",
				Position = new Position(58.107913, 56.318169),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (химия)
        List<Pin> ChemPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Промотходы",
				Address = "Кронштадтская ул., 39А",
				Position = new Position(57.996946, 56.204569),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторпроект",
				Address = "Рязанская ул., 101",
				Position = new Position(57.970401, 56.180906),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "НПП Эруто",
				Address = "ул. Солдатова, 44",
				Position = new Position(57.975814, 56.243235),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (фарма)
        List<Pin> PharmaPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "НПП Эруто",
				Address = "ул. Солдатова, 44",
				Position = new Position(57.975814, 56.243235),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторпроект",
				Address = "Рязанская ул., 101",
				Position = new Position(57.970401, 56.180906),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (электронные)
        List<Pin> ElectroPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Уфпг",
				Address = "ш. Космонавтов, 111Б, корп. 45",
				Position = new Position(57.990518, 56.210428),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "АО Про Тко",
				Address = "ул. Чкалова, 9Д",
				Position = new Position(57.984629, 56.263089),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Экологические Системы",
				Address = "Хлебозаводская ул., 19А/2",
				Position = new Position(57.970426, 56.254553),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (органические)
        List<Pin> FoodPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Уфпг",
				Address = "ш. Космонавтов, 111Б, корп. 45",
				Position = new Position(57.990518, 56.210428),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Вторпроект",
				Address = "Рязанская ул., 101",
				Position= new Position(57.970401, 56.180906),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "НПП Эруто",
				Address = "ул. Солдатова, 44",
				Position = new Position(57.975814, 56.243235),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "ТКО-Прикамье",
				Address = "1-я Бахаревская ул., 53, корп. 4",
				Position = new Position(57.952086, 56.238480),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (садовые)
        List<Pin> GardenPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Вторпроект",
				Address = "Рязанская ул., 101",
				Position= new Position(57.970401, 56.180906),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "НПП Эруто",
				Address = "ул. Солдатова, 44",
				Position = new Position(57.975814, 56.243235),
				Type = PinType.Place
			},
		};

        //Список пинов для обозначений на карте (животные)
        List<Pin> AnimalPins = new List<Pin>()
		{
			new Pin()
			{
				Label = "НПП Эруто",
				Address = "ул. Солдатова, 44",
				Position = new Position(57.975814, 56.243235),
				Type = PinType.Place
			},
			new Pin()
			{
				Label = "Склад",
				Address = "Сахалинская ул., 2",
				Position = new Position(57.975680, 56.316610),
				Type = PinType.Place
			},
		};

        //Шаблон

        /*List<Pin> Pins = new List<Pin>()
		{
			new Pin()
			{
				Label = "Название организации",
				Address = "Адрес",
				Position = new Position(57.987635, 56.240165), //Координаты
				Type = PinType.Place
			},
		};*/


        public Map()
		{
			InitializeComponent();  //Инициализация карты

			//var map = new Xamarin.Forms.Maps.Map(new MapSpan(new Position(58.010455, 56.229443), 58.010455, 56.229443));

			
		}
		public Map(MapMode mode)
		{
			InitializeComponent();
			switch (mode)
			{
				case MapMode.Plastic: 
					{ 
						foreach (Pin pin in PlasticPins) 
							map.Pins.Add(pin);
						wasteLabel.Text = "Пункты приёма пластика";
						wasteLabel.IsVisible = true;
						break; 
					}
				case MapMode.Paper: 
					{ 
						foreach (Pin pin in PaperPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма бумаги";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Food: 
					{ 
						foreach (Pin pin in FoodPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма пищевых отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Chem: 
					{ 
						foreach (Pin pin in ChemPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма химических отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Pharma: 
					{ 
						foreach (Pin pin in PharmaPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма фарм отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Electro: 
					{ 
						foreach (Pin pin in ElectroPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма электронных отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Battaries: 
					{ 
						foreach (Pin pin in BattariesPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма батареек";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Garden: 
					{ 
						foreach (Pin pin in GardenPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма садовых отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Animal: 
					{ 
						foreach (Pin pin in AnimalPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма животных отходов";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Metal: 
					{ 
						foreach (Pin pin in MetalPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма металла";
                        wasteLabel.IsVisible = true;
                        break; 
					}
				case MapMode.Glass: 
					{ 
						foreach (Pin pin in GlassPins) 
							map.Pins.Add(pin);
                        wasteLabel.Text = "Пункты приёма стекла";
                        wasteLabel.IsVisible = true;
                        break; 
					}
			}
		}

		void Toggle(MapMode mode)
		{
            while (map.Pins.Count != 0)
			{
				map.Pins.RemoveAt(0);
				wasteLabel.IsVisible = false;
            }
            if (CurrentMode != mode)
				switch (mode)
				{
					case MapMode.Paper:
						{
							foreach (Pin pin in PaperPins) map.Pins.Add(pin);
							wasteLabel.IsVisible=true;
							CurrentMode = MapMode.Paper;
							break;
						}
					case MapMode.Food:
						{
							foreach (Pin pin in FoodPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Food;
							break;
						}
					case MapMode.Plastic:
						{
							
							foreach (Pin pin in PlasticPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Plastic;
							break;
						}
					case MapMode.Chem:
						{
							foreach (Pin pin in ChemPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Chem;
							break;
						}
					case MapMode.Pharma:
						{
							foreach (Pin pin in PharmaPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Pharma;
							break;
						}
					case MapMode.Garden:
						{
							foreach (Pin pin in GardenPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Garden;
							break;
						}
					case MapMode.Animal:
						{
                            foreach (Pin pin in AnimalPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Animal;
							break;
						}
					case MapMode.Battaries:
						{
							foreach (Pin pin in BattariesPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Battaries;
							break;
						}
					case MapMode.Electro:
						{
							
							foreach (Pin pin in ElectroPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Electro;
							break;
						}
					case MapMode.Glass:
						{
							foreach (Pin pin in GlassPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Glass;
							break;
						}
					case MapMode.Metal:
						{
							foreach (Pin pin in MetalPins) map.Pins.Add(pin);
                            wasteLabel.IsVisible = true;
                            CurrentMode = MapMode.Metal;
							break;
						}
				}
			else CurrentMode = MapMode.None;
		}

       
        private void WasteTypeMapClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				Button button = sender as Button;
				if (button == animal)
				{
                    Toggle(MapMode.Animal);
                    wasteLabel.Text = "Пункты приёма животных отходов";
				}
				else if (button == battaries)
                {
                    Toggle(MapMode.Battaries);
                    wasteLabel.Text = "Пункты приёма батареек";
                } 
				else if (button == chem)
                {
                    Toggle(MapMode.Chem);
                    wasteLabel.Text = "Пункты приёма химических отходов";
                }
				else if (button == electro)
				{
                    Toggle(MapMode.Electro);
                    wasteLabel.Text = "Пункты приёма электронных отходов";
                }
				else if (button == garden)
				{
                    Toggle(MapMode.Garden);
                    wasteLabel.Text = "Пункты приёма садовых отходов";
                }
				else if (button == glass)
				{
                    Toggle(MapMode.Glass);
                    wasteLabel.Text = "Пункты приёма стекла";
                }
				else if (button == metal)
				{
                    Toggle(MapMode.Metal);
                    wasteLabel.Text = "Пункты приёма металла";
                }
				else if (button == organic)
				{
                    Toggle(MapMode.Food);
                    wasteLabel.Text = "Пункты приёма пищевых отходов";
                }
				else if (button == paper)
				{
                    Toggle(MapMode.Paper);
                    wasteLabel.Text = "Пункты приёма бумаги";
                }
				else if (button == pharma)
				{
                    Toggle(MapMode.Pharma);
                    wasteLabel.Text = "Пункты приёма фарм отходов";
                }
				else if (button == plastic)
				{
                    Toggle(MapMode.Plastic);
                    wasteLabel.Text = "Пункты приёма пластика";
                }
            }
		}


        /// <summary>
        /// Возврат на главную страницу с текущей
        /// </summary>
        private async void backHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
        }


        /// <summary>
        /// Назад - возвращение на предыдущую страницу
        /// </summary>
        private async void backClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
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