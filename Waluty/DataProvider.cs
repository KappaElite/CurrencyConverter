namespace Currency;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

public class DataProvider
{
    private static DataProvider _provider = null;
    private string _url = "https://api.nbp.pl/api/exchangerates/tables/a/";
    private XDocument _xmlDocument;

    private DataProvider()
    {

    }

    public XDocument XmlDocument
    {
        get{
            return _xmlDocument;
        }
    }

    public static DataProvider GetInstance()
    {
        if (_provider == null)
        {
            _provider = new DataProvider();
        }

        return _provider;
    }
    
    public async Task GetData()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    string xmlContent = await response.Content.ReadAsStringAsync();
                    XDocument xmlDocument = XDocument.Parse(xmlContent);
                    _xmlDocument = xmlDocument;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}