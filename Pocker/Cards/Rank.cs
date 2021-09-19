using System.ComponentModel;

namespace Pocker.Cards
{
	public enum Rank
	{
		[Description("2")]
		Two = 2,
		[Description("3")]
		Three = 3,
		[Description("4")]
		Four = 4,
		[Description("5")]
		Five = 5,
		[Description("6")]
		Six = 6,
		[Description("7")]
		Seven = 7,
		[Description("8")]
		Eight = 8,
		[Description("9")]
		Nine = 9,
		[Description("10")]
		Ten = 10,
		[Description("Валет")]
		Jack = 11,
		[Description("Дама")]
		Queen = 12,
		[Description("Король")]
		King = 13,
		[Description("Туз")]
		Ace = 14
	}
}
