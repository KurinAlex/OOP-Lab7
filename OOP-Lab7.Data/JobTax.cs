namespace OOP_Lab7.Data;

public class JobTax : Tax
{
	private const double MaxBenefitedAmount = 2684.0;
	private const double BenefitAmount = 0.5 * MaxBenefitedAmount;

	protected override double Percent => 15.0;
	public override string Name => "Job";

	protected override double GetTaxedAmount()
	{
		double amount = Person.MainJobIncome + Person.AdditionalJobIncome;
		if (amount <= MaxBenefitedAmount)
		{
			amount -= BenefitAmount;
		}
		if (Person.ChildrenCount > 1)
		{
			amount -= BenefitAmount * Person.ChildrenCount;
		}
		return amount;
	}
}
