using InvestmentTracker.Core;
using InvestmentTracker.Core.Pocos;
using static System.Console;

namespace InvestmentTracker.Console;

public class Program
{
    public static void Main()
    {
        var configuration = System.Text.Json.JsonSerializer.Deserialize<List<InvestmentConfiguration>>(File.ReadAllText("configuration.json"));

        var scraper = new Scraper(configuration);

        var results = scraper.GetPrices();

        foreach (var result in results)
        {
            WriteLine($"{result.Id}: {result.Price}");
        }
    }
}