namespace OOP_Lab7.Data;

public abstract class Tax
{
    public Tax()
    {
        UpdateAmount();
    }

    public int Id { get; set; }

    public required Person Person { get; init; }
    public double Amount { get; private set; }
    protected abstract double Percent { get; }
    public abstract string Name { get; }

    public void UpdateAmount() => Amount = GetTaxedAmount() * Percent;
    protected abstract double GetTaxedAmount();
}
