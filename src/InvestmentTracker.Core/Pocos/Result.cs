namespace InvestmentTracker.Core.Pocos;

public class Result
{
    public int Id { get; }

    public decimal Price { get; }

    public Result(int id, decimal price)
    {
        Id = id;

        Price = price;
    }
}