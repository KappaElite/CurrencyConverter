using Currency;

DataProvider dataProvider = DataProvider.GetInstance();
await dataProvider.GetData();
CurrencyCollection test = new CurrencyCollection(dataProvider.XmlDocument);
Menu menu = new Menu(test);
menu.MainMenu();

