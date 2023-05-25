using System.ComponentModel;

namespace OOP_Lab7.Data;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    [DisplayName("Main Job")]
    public double MainJobIncome { get; set; }
    [DisplayName("Additional Job")]
    public double AdditionalJobIncome { get; set; }
    [DisplayName("Author Awards")]
    public double AuthorAwardsAmount { get; set; }
    [DisplayName("Goods Sells")]
    public double GoodsSellsIncome { get; set; }
    [DisplayName("Money Gifts")]
    public double MoneyGiftsAmount { get; set; }
    [DisplayName("Goods Gifts")]
    public double GoodsGiftsAmount { get; set; }
    [DisplayName("Abroad Transfers")]
    public double AbroadTransfersAmount { get; set; }
    [DisplayName("Children")]
    public int ChildrenCount { get; set; }

    public ICollection<Tax> Taxes { get; set; } = new List<Tax>();
}
