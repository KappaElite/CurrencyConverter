using System.Collections;
using System.Xml.Linq;
using System.Globalization;

namespace Currency;

public class CurrencyCollection : ICurrencyCollection, IEnumerable
{
    private List<Currency> _currencies = new List<Currency>();
    
    
    public IEnumerator<Currency> GetEnumerator()
    {
        return _currencies.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    
    public CurrencyCollection(XDocument xDocument)
    {
        AddDataToList(xDocument);
        _currencies.Add(new Currency("Zloty", "PLN", 1.0));
    }
    
    public void Add(Currency element)
    {
        _currencies.Add(element);
    }

    public void Remove(Currency element)
    {
        _currencies.Remove(element);
    }

    public Currency GetCurrency(int index)
    {
        return _currencies[index];
    }

    public void ShowAllCurrencies()
    {
        foreach (var currency in _currencies)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Name: {currency.Name}");
            Console.WriteLine($"Code: {currency.Code}");
            Console.WriteLine($"Rate: {currency.Rate}");
            Console.WriteLine("-----------------------");
        }
    }

    public bool CheckSymbol(string symbol)
    {
        foreach (var value in _currencies)
        {
            if (value.Code == symbol)
            {
                return true;
            }
        }

        return false;
    }

    private void AddDataToList(XDocument xDocument)
    {
        foreach (XElement currency in xDocument.Descendants("Rate"))
        {
            string name = currency.Element("Currency")?.Value;
            string code = currency.Element("Code")?.Value;
            string value = currency.Element("Mid")?.Value;
            double valueToDouble = double.Parse(value, CultureInfo.InvariantCulture);
            Add(new Currency(name,code,valueToDouble));
            
        }
    }
}