using HtmlAgilityPack;
using InvestmentTracker.Core.Exceptions;
using InvestmentTracker.Core.Pocos;

namespace InvestmentTracker.Core;

public class Scraper
{
    private readonly List<InvestmentConfiguration> _configurations;

    public Scraper(List<InvestmentConfiguration> configurations)
    {
        _configurations = configurations;
    }

    public List<Result> GetPrices()
    {
        var prices = new List<Result>();

        foreach (var configuration in _configurations)
        {
            var web = new HtmlWeb();

            var document = web.Load(configuration.Url);

            var data = document.DocumentNode.SelectSingleNode(configuration.XPath);

            var priceText = data.InnerText.Replace("&pound;", "£");

            if (priceText.EndsWith("p"))
            {
                prices.Add(new Result(configuration.Id, decimal.Parse(priceText[..^1])));

                continue;
            }

            if (priceText.StartsWith("£"))
            {
                prices.Add(new Result(configuration.Id, decimal.Parse(priceText[1..]) * 100));

                continue;
            }

            throw new ScrapingException($"Unable to parse price in this format: {priceText}");
        }

        return prices;
    }
}