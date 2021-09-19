using Pocker.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pocker.Hands
{
	public class HandBase
	{
		private int _initialCardCount;
		private List<CardBase> _cards = new List<CardBase>(2);

		private void CheckIfShuffleInvalid(int initialCount, IEnumerable<CardBase> initialCards)
		{
			if (initialCards?.Count() != initialCount)
				throw new Exception($"Раздача руки не корректна: карт {initialCards?.Count() ?? 0}");
		}

		public HandBase(int initialCount, IEnumerable<CardBase> initialCards): this(initialCount)
		{
			CheckIfShuffleInvalid(initialCount, initialCards);
			AddCards(initialCards);
		}

		public HandBase(int initialCount)
		{
			_initialCardCount = initialCount;
		}

		public IEnumerable<CardBase> Cards => _cards;
		public int CardsCount => Cards?.Count() ?? 0;

		public void AddCards(IEnumerable<CardBase> cards)
		{
			_cards.AddRange(cards);
		}

		public void AddCard(CardBase card)
		{
			_cards.Add(card);
		}

		public HandRank CalculateHandRank()
		{
			throw new NotImplementedException();
		}
		
	}
}
