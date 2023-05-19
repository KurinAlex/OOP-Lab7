namespace OOP_Lab7.Data;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public double MainJobIncome { get; set; }
    public double AdditionalJobIncome { get; set; }
    public double AuthorAwardsAmount { get; set; }
    public double GoodsSellsIncome { get; set; }
    public double MoneyGiftsAmount { get; set; }
    public double GoodsGiftsAmount { get; set; }
    public double AbroadTransfersAmount { get; set; }
    public int ChildrenCount { get; set; }

    public ICollection<Tax> Taxes { get; set; } = new List<Tax>();
}
