using Pocker.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pocker.Test
{
	public class CardBaseTests
	{
        [Fact]
        public void Name_Should_Exist()
        {
            var card = new CardBase(Rank.Jack, Suit.Heart);
            
            string cardName = card.Name;

            Assert.False(string.IsNullOrWhiteSpace(cardName));
        }

        [Fact]
        public void Name_Should_Be_Right()
        {
            var card = new CardBase(Rank.Jack, Suit.Heart);

            string cardName = card.Name;

            Assert.Equal("Валет Черви", cardName);
        }
    }
}
