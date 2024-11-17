namespace Currency;

public class Currency
{
    private string _name;
    private string _code;
    private double _rate;

    public Currency(string name, string code, double rate)
    {
        _name = name;
        _code = code;
        _rate = rate;
    }
    
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Code
    {
        get { return _code; }
        set { _code = value; }
    }

    public double Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }
}