namespace OOP_Lab7.Data;

public abstract class Tax
{
    public int Id { get; set; }

    public required Person Person { get; init; }
    public double Amount { get; private set; }
    protected abstract double Percent { get; }
    public abstract string Name { get; }

    public void UpdateAmount()
    {
        double amount = Percent / 100.0 * GetTaxedAmount() ;
        Amount = amount < 0.0 ? 0.0 : amount;
    }
    protected abstract double GetTaxedAmount();
}
