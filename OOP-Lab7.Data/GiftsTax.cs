namespace OOP_Lab7.Data;

public class GiftsTax : Tax
{
	protected override double Percent => 18.0;
	public override string Name => "Gifts";

	protected override double GetTaxedAmount()
		=> Person.MoneyGiftsAmount + Person.GoodsGiftsAmount;
}
