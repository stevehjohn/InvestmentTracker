namespace InvestmentTracker.Core.Exceptions;

public class ScrapingException : Exception
{
    public ScrapingException(string message) : base(message)
    {
    }
}