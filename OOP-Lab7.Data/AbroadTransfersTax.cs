namespace OOP_Lab7.Data;

public class AbroadTransfersTax : Tax
{
	protected override double Percent => 18.0;
	public override string Name => "Abroad transfers";

	protected override double GetTaxedAmount() => Person.AbroadTransfersAmount;
}
