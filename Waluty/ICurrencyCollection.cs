namespace Currency;

public interface ICurrencyCollection
{
    void Add(Currency element);
    void Remove(Currency element);
    Currency GetCurrency(int index);
}