﻿namespace OOP_Lab7.Data;

public class GoodsTax : Tax
{
	protected override double Percent => 0.5;
	public override string Name => "Goods";

	protected override double GetTaxedAmount()
		=> Person.GoodsGiftsAmount + Person.GoodsSellsIncome;
}
