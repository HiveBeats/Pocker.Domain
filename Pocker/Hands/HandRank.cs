using System.ComponentModel;

namespace Pocker.Hands
{
	public enum HandRank
	{
		[Description("Старшая карта")]
		HighCard = 1,
		[Description("Пара")]
		Pair = 2,
		[Description("Две пары")]
		TwoPair = 3,
		[Description("Сет")]
		ThreeOfAKind = 4, //Сет
		[Description("Стрит")]
		Straight = 5,
		[Description("Флеш")]
		Flush = 6,
		[Description("Фулл-хаус")]
		FullHouse = 7,
		[Description("Каре")]
		FourOfAKind = 8, //Каре
		[Description("Стрит-флеш")]
		StraightFlush = 9,
		[Description("Роял флеш")]
		RoyalFlush = 10
	}
}
