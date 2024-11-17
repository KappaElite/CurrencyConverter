namespace Currency;

public class Exchanger
{
    private static Exchanger _exchanger = null;
    
    private Exchanger()
    {
        
    }

    public static Exchanger GetInstance()
    {
        if (_exchanger == null)
        {
            _exchanger = new Exchanger();
        }
        return _exchanger;
    }

    public double ExchangeCurrencies(CurrencyCollection currencyCollection, string startingSymbol, double money, string destinationSymbol)
    {
        double exchangedMoney = 0;
        foreach (var value in currencyCollection)
        {
            if (value.Code == startingSymbol)
            {
                exchangedMoney = money * value.Rate;
                break;
            }
        }

        foreach (var value in currencyCollection)
        {
            if (value.Code == destinationSymbol)
            {
                exchangedMoney /= value.Rate;
                break;
            }
        }

        return exchangedMoney;
    }
}