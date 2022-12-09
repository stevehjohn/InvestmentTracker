namespace InvestmentTracker.Core;

public class Scraper
{
    private readonly Configuration _configuration;

    public Scraper(Configuration configuration)
    {
        _configuration = configuration;
    }

    public List<Result> GetPrices()
    {
        var prices = new List<Result>();

        return prices;
    }
}