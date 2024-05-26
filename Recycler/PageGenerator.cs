using Xamarin.Forms;

namespace Recycler
{
	internal class PageGenerator : ContentPage
	{
		public enum Type
		{
			Recyclable,
			Hazardous,
			Organic,

			Paper,
			Glass,
			Plastic,
			Metal,

			Battaries,
			Chemistry,
			Pharma,
			Electro,

			Food,
			Garden,
			Animal,

			Composting,
			Disposer
		}
		public ContentPage GeneratePage(Type type, INavigation el)
		{
			Button bt_composting = new Button() { Text = "Узнать больше" }; bt_composting.Clicked += (a, e) => el.PushAsync(GeneratePage(Type.Composting, el));
			Button bt_disposer = new Button() { Text = "Узнать больше" }; bt_disposer.Clicked += (a, e) => el.PushAsync(GeneratePage(Type.Disposer, el));
			Button[] bts;
			switch (type)
			{
				case Type.Recyclable:
					{
						Button bt_paper, bt_glass, bt_plastic, bt_metal;
						bt_paper = new Button() { Text = "Бумага" }; bt_paper.Clicked += (e, a) => el.PushAsync(GeneratePage(Type.Paper,el));
						bt_glass = new Button() { Text = "Стекло" }; bt_glass.Clicked += (e, a) => el.PushAsync(GeneratePage(Type.Glass, el));
						bt_plastic = new Button() { Text = "Пластик" }; bt_plastic.Clicked += (e, a) => el.PushAsync(GeneratePage(Type.Plastic, el));
						bt_metal = new Button() { Text = "Металл" }; bt_metal.Clicked += (e, a) => el.PushAsync(GeneratePage(Type.Metal, el));
						bts = new Button[] { bt_glass, bt_paper, bt_plastic, bt_metal };

						return new SelectionPage(bts);
					}
				case Type.Hazardous:
					{
						Button bt_battaries, bt_chemistry, bt_pharma, bt_electro;
						bt_battaries = new Button() { Text = "Батарейки и аккумуляторы" }; bt_battaries.Clicked += (e, a) => { el.PushAsync(GeneratePage(Type.Battaries, el)); };
						bt_chemistry = new Button() { Text = "Химические вещества" }; bt_chemistry.Clicked += (e, a) => { el.PushAsync(GeneratePage(Type.Chemistry, el)); };
						bt_pharma = new Button() { Text = "Фармацевтические препараты" }; bt_pharma.Clicked += (e, a) => { el.PushAsync(GeneratePage(Type.Pharma, el)); };
						bt_electro = new Button() { Text = "Электронные отходы" }; bt_electro.Clicked += (e, a) => { el.PushAsync(GeneratePage(Type.Electro, el)); };

						bts = new Button[] { bt_battaries, bt_chemistry, bt_pharma, bt_electro };
						return new SelectionPage(bts);
					}
				case Type.Organic:
					{
						Button bt_food, bt_garden, bt_animal;
						bt_food = new Button() { Text = "Пищевые отходы" }; bt_food.Clicked += (a, e) => { el.PushAsync(GeneratePage(Type.Food, el)); };
						bt_garden = new Button() { Text = "Садовые отходы" }; bt_garden.Clicked += (a, e) => { el.PushAsync(GeneratePage(Type.Garden, el)); };
						bt_animal = new Button() { Text = "Животные отходы" }; bt_animal.Clicked += (a, e) => { el.PushAsync(GeneratePage(Type.Animal, el)); };

						bts = new Button[] { bt_food, bt_garden, bt_animal };
						return new SelectionPage(bts);
					}

				case Type.Paper:
					{
						Article[] paper =
				{
					new Article("Какая макулатура принимается в переработку?", new string[]
					{
						"Картон",
						"Печатная продукция:\r\nкниги, глянцевые журналы,\r\nгазеты, офисная бумага, тетради,\r\nпочтовый спам, бумажная упаковка",
						"Измельчённая бумага",
						"Рисунки с гуашью, акварелью,\r\nс клеем, цветной бумагой, мелками фломастерами, карандашами",
						"Календари"
					},Article.HorizontalOptions.Right),

					new Article("Какая макулатура не принимается в переработку?", new string[]
					{
						"Упаковка от соков, молочных продуктов",
						"Грязная макулатура ",
						"Бумажные салфетки и полотенца",
						"Бумажные стаканчики",
						"Чеки и бумага для факсов",
						"Фотобумага",
						"Обои",
						"Рисунки из мелков, растопленных утюгом; рисунки из пластилина; картины масляными красками"
					},Article.HorizontalOptions.Left),

					new Article("Как подготовить к переработке?", new string[]
					{
						"Убедиться в отсутствии тонкой плёнки ламинирования - надорвите край изделия, если плёнка не тянется и не видна, то можно сдавать",
						"Удалить металлические элементы — пружины, скрепки, скобы от степлера.\r\n",
						"Удалить пластиковые элементы.",
						"Объемные коробки сложить",
						"Все стопки перевязать верёвкой (бечёвкой)."
					},Article.HorizontalOptions.Right)
				};
						return new InfoPage("Бумага", paper, Map.MapMode.Paper);
					}
				case Type.Plastic:
					{
						Article[] plastic =
						{
							new Article("Почему нельзя на свалку?", new string[]
							{
								"Пластик не поддаётся биологическому разложению. он распадается на части, становясь микропластиком, и разлагается до 1000 лет",
								"Он душит морскую флору и фауну, наносит ущерб почве и отравляет подземные воды"
							},Article.HorizontalOptions.Left),
							new Article("Не пригодно к переработке", new string[]
							{
								"Пластик с OTHER/C/PP/без маркировки на упаковке",
								"Вакуумные упаковки",
								"Пакеты из биоразлагаемого материала",
								"Плетённые мешки"
							},Article.HorizontalOptions.Right)
						};
						return new InfoPage("Пластик", plastic,Map.MapMode.Plastic);
					}
				case Type.Glass:
					{
						Article[] glass =
						{
							new Article("Почему нельзя на свалку?", new string[]
					{
						"Занимает много место на свалке и распадается на составляющие в период 500-1000 лет",
						"В разбитом виде может поранить животных, а в летний день  сфокусировать солнечные лучи и вызвать пожар"
					},Article.HorizontalOptions.Left),

							new Article("В переработку не примут:", new string[]
					{
						"Лампочки",
						"Керамическую и стеклянную посуду",
						"Оптическое стекло"
					},Article.HorizontalOptions.Right),
						};
						return new InfoPage("Стекло", glass, Map.MapMode.Glass);
					}
				case Type.Metal:
					{
						Article[] metal =
						{
							new Article("Почему нельзя на свалку?",new string[]
							{
								"Очень долгий процесс распада, в течение которого образуется множество отравляющих веществ.",
								"На отравленной почве выращиваются культуры, употребляемые человеком и животными, в организмах которых происходит накопительных эффект вредных веществ."
							},Article.HorizontalOptions.Left),
							new Article("Не пригодно к переработке", new string[]
							{
								"всё, что относится к вооруженным силам",
								"исправный транспорт",
								"неразрезанные баллоны и баки",
								"железнодорожное оборудование",
								"электрическое оборудование"
							},Article.HorizontalOptions.Right)
						};
						return new InfoPage("Металл", metal, Map.MapMode.Metal);
					}

				case Type.Battaries:
				{
					Article[] battaries = new Article[]
						{
							new Article("Почему нельзя на свалку?", new string[]
								{
									"Ржавеют горят и выделяют в окружающую среду целый набор ядовитых веществ, тяжелых металлов: кадмий, марганец, никель, ртуть, свинец, цинк",
									"Вода в свою очередь вымывает их из почвы и несёт в грунтовые воды и водоёмы"
								}, Article.HorizontalOptions.Right),
							new Article("Что запрещается?", new string[]
							{
								"Накопление отработанных элементов питания в неустановленных местах и более 11 месяцев",
								"Выброс отработанных элементов питания в контейнеры для мусора",
								"Передача лицам, не имеющим лицензии на переработку"
							}, Article.HorizontalOptions.Left)
						};
					return new InfoPage("Батарейки и аккумуляторы", battaries, Map.MapMode.Battaries);
				}
				case Type.Chemistry:
					{
						Article[] chemistry = new Article[]
						{
							new Article("Почему важно утилизировать?",new string[]
							{
								"Сокращение количества отходов",
								"Максимальное использование потенциала вторсырья и поддержание его в обороте",
								"открытие новых применений восстановленных полуфабрикатов и продуктов"
							},Article.HorizontalOptions.Left),
							new Article("Как хранить?", new string[]
							{
								"Отдельно от обычных бытовых отходов",
								"Пометить ёмкость яркой и чёткой надписью",
								"В прохладном, сухом, недоступном для детей месте, вдали от солнечных лучей",
								"Не смешивать видя ядовитого мусора",
								"Хранить не более 6 месяцев"
							},Article.HorizontalOptions.Right)
						};
						return new InfoPage("Химические вещества", chemistry, Map.MapMode.Chem);
					}
				case Type.Pharma:
					{
						Article[] pharma = new Article[]
						{
							new Article("Почему нельзя на свалку?", new string[]
							{
								"Многие препараты содержат токсичные и даже радиационные компоненты, которые оказывает губительное влияние на экосистемы",
								"Под постоянным влиянием антибиотиков опасные для здоровья бактерии вырабатывают устойчивость к препаратам"
							},Article.HorizontalOptions.Left),
							new Article("Какие препараты можно сдавать?",new string[]
							{
								"просроченные средства",
								"препараты без идентификации",
								"одиночные таблетки без блистера",
								"слипшиеся капсулы",
								"внешний вид изменён"
							},Article.HorizontalOptions.Right)
						};
						return new InfoPage("Фармацевтические препараты", pharma, Map.MapMode.Pharma);
					}
				case Type.Electro:
					{
						Article[] electro = new Article[]
						{
							new Article("Почему нельзя на свалку?",new string[]
							{
								"Их детали не разлагаются",
								"Сжигание гаджетов способствует выделению вредных веществ",
								"Корпус изготовлен из пластмассы, а аккумулятор содержит ядовитые соединения"
							},Article.HorizontalOptions.Left),
							new Article("Как подготовить к переработке?",new string[]
							{
								"Отформатируйте функциональные части",
								"Извлеките и сотрите данные с жёсткого диска",
								"Выньте батарейки"
							},Article.HorizontalOptions.Right)
						};
						return new InfoPage("Электронные отходы", electro, Map.MapMode.Electro);
					}

				case Type.Food:
				{
						Article[] food = new Article[]
						{
							new Article("Почему нельзя на свалку?",new string[]
							{
								"При разложении продуктов питания на свалке выделяется метан, мощный парниковый газ",
								"Гниющая пища – среда развития видов животных и насекомых, являющихся распространителями серьёзных заболеваний"
							},Article.HorizontalOptions.Left),
							new Article("Как перерабатывать самостоятельно?", new string[]
							{
								"Компостирование"
							},Article.HorizontalOptions.Right, bt_composting),
							new Article("",new string[]
							{
								"Диспоузер"
							},Article.HorizontalOptions.Right,bt_disposer)
						};
						return new InfoPage("Пищевые отходы", food, Map.MapMode.Food);
				}
				case Type.Garden:
				{
						Article[] garden = new Article[]
						{
							new Article("Как подготовить к переработке?",new string[]
							{
								"Свести к минимуму количество пластика и крупных камней",
								"Черенки травы, в которой использовались гербициды, не должны попадать в мусорное ведро",
								"Отходы общественного питания или животноводства не должны попадать садовый мусорный бак"
							},Article.HorizontalOptions.Right),
							new Article("Как перерабатывать самостоятельно?", new string[]
							{
								"Компостирование",
							},Article.HorizontalOptions.Left, bt_composting)
						};
						return new InfoPage("Садовые отходы", garden, Map.MapMode.Garden);
				}
				case Type.Animal:
					{
						Article[] animal = new Article[]
						{
							new Article("Почему нельзя на свалку?", new string[]
							{
								"На открытом воздухе и под действием внешних факторов происходит разложение остатков, при котором формируется благоприятная среда для развития бактерий и распространения инфекций"
							},Article.HorizontalOptions.Left),
							new Article("Как перерабатывать самостоятельно?", new string[]
							{
								"Компостирование"
							},Article.HorizontalOptions.Right, bt_composting)
						};
						return new InfoPage("Животные отходы", animal, Map.MapMode.Animal);
					}
				case Type.Composting:
					{
						Article[] articles =
							{
								new Article("Превращение пищевых отходов в землю",new string[]
								{
									"Ящик с субстратом, в котором живут черви. Черви и микроорганизмы превращают пищевые отходы в землю"
								},Article.HorizontalOptions.Left),
								new Article("Плюсы:",new string[]
								{
									"Не затратно",
									"Это готовое удобрение. За день червь способен переработать столько органики, сколько весит он сам"
								},Article.HorizontalOptions.Left),
								new Article("Минусы:",new string[]
								{
									"Черви требуют ухода и далеко не всеядны",
									"При неправильном уходе черви могут погибнуть или в субстрате заведутся мошки",
									"Не все могут быть рады появлению в доме червеи",
									"Придётся позаботиться о том, куда пристроить получившееся удобрение"
								},Article.HorizontalOptions.Right)
							};
						return new InfoPage("Компостирование", articles, Map.MapMode.None);
				}
				case Type.Disposer:
					{
						Article[] articles =
							{
								new Article("Измельчитель пищевых отходов", new string[]
								{
									"Просто бросаете отходы в раковину, включаете прибор и небольшую струю воды"
								},Article.HorizontalOptions.Left),
								new Article("Плюсы", new string[]
								{
									"Долговечен",
									"Безопасен",
									"“Всеяден”",
									"Удобен в использовании",
									"Освобождает мусорное ведро"
								},Article.HorizontalOptions.Left),
								new Article("Минусы:", new string[]
								{
									"Недёшево",
									"Органика, попавшая в канализацию, перерабатывается крайне редко"
								},Article.HorizontalOptions.Right)
							};
						return new InfoPage("Диспоузер", articles, Map.MapMode.None);
					}
				default: return null;
			}
		}
	}
}
