namespace Currency;

public class Menu
{
    private CurrencyCollection _currencyCollection;

    public Menu(CurrencyCollection currencyCollection)
    {
        _currencyCollection = currencyCollection;
    }
    
    public  void MainMenu()
    {
        String userInput = "";
        Console.WriteLine("Exchnge menu");
        Console.WriteLine("Choose one of the available options:");
        while (userInput != "0")
        {
            Console.WriteLine("[2]Exchange");
            Console.WriteLine("[1]Show all currencies rates");
            Console.WriteLine("[0]Exit");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case"2":
                    string userSymbolStarting;
                    string userSymbolDestination;
                    string userMoney;
                    double userMoneyToDouble;
                    double result;
                    Exchanger exchanger = Exchanger.GetInstance();
                    Console.WriteLine("Provide symbol of your currency:");
                    userSymbolStarting = Console.ReadLine();
                    if (!_currencyCollection.CheckSymbol(userSymbolStarting))
                    {
                        Console.WriteLine("Wrong symbol! Try Again");
                        continue;
                    }
                    Console.WriteLine("Provide amount of money you want to exchange:");
                    userMoney = Console.ReadLine();
                    bool moneyCheck = Double.TryParse(userMoney, out userMoneyToDouble);
                    if (moneyCheck == false || userMoneyToDouble <= 0)
                    {
                        Console.WriteLine("Negative amount of money or wrong format. Try again");
                        continue;
                    }
                    Console.WriteLine("Provide symbol of destinated currency");
                    userSymbolDestination = Console.ReadLine();
                    if (!_currencyCollection.CheckSymbol(userSymbolStarting))
                    {
                        Console.WriteLine("Wrong symbol! Try Again");
                        continue;
                    }
                    
                    result = exchanger.ExchangeCurrencies(_currencyCollection, userSymbolStarting, userMoneyToDouble, userSymbolDestination);
                    Console.WriteLine($"Exchanged value: {result:F2}");
                    break;
                case "1":
                    _currencyCollection.ShowAllCurrencies();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Wrong symbol, try again");
                    break;
            }
        }
    }
}