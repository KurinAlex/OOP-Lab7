namespace OOP_Lab7.Data;

public class MilitaryTax : Tax
{
	protected override double Percent => 1.5;
	public override string Name => "Military";

	protected override double GetTaxedAmount()
		=> Person.MainJobIncome + Person.AdditionalJobIncome + Person.AbroadTransfersAmount;
}
