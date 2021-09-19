using Pocker.Infrastructure;

namespace Pocker.Cards
{
	public class CardBase
	{
		public CardBase(Rank rank, Suit suit)
		{
			Rank = rank;
			Suit = suit;
			Name = GetName();
		}

		public string Name { get; private set; }
		public Rank Rank { get; private set; }
		public Suit Suit { get; private set; }

		private string GetName()
		{
			var rankName = DescriptionHelper.Get(Rank);
			var suitName = DescriptionHelper.Get(Suit);

			return $"{rankName} {suitName}";
		}
	}
}
