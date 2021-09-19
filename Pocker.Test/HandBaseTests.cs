using System;
using System.Collections.Generic;
using Pocker.Cards;
using Pocker.Hands;
using Xunit;

namespace Pocker.Test
{
    public class HandBaseTests
    {
        [Fact]
        public void Should_Construct_Without_Cards()
        {
            bool excepted = false;
            try
            {
                var hand = new HandBase(2);
            }
            catch (Exception e)
            {
                excepted = true;
            }

            Assert.False(excepted);
        }

        [Fact]
        public void Should_Construct_With_Cards()
        {
            bool excepted = false;
            HandBase hand = null;
            try
            {
                hand = new HandBase(1, new List<CardBase>() {new CardBase(Rank.Ace, Suit.Clover)});
            }
            catch (Exception e)
            {
                excepted = true;
            }

            Assert.False(excepted);
            Assert.NotNull(hand);
        }

        [Fact]
        public void Should_Throw_With_Invalid_Cards_Count()
        {
            HandBase hand;
            Assert.Throws<Exception>(() =>
                hand = new HandBase(2, new List<CardBase>() {new CardBase(Rank.Ace, Suit.Clover)}));
        }

        [Fact]
        public void Should_Throw_With_Empty_Cards()
        {
            HandBase hand;
            Assert.Throws<Exception>(() => hand = new HandBase(1, new List<CardBase>()));
        }

        [Fact]
        public void Should_Throw_With_Null_Cards()
        {
            HandBase hand;
            Assert.Throws<Exception>(() => hand = new HandBase(1, null));
        }

        [Fact]
        public void Should_Equal_Cards_Count_After_Shuffle()
        {
            var cardCount = 2;
            var hand = new HandBase(cardCount,
                new List<CardBase>() {new CardBase(Rank.Ace, Suit.Clover), new CardBase(Rank.Eight, Suit.Heart)});
            
            Assert.Equal(cardCount, hand.CardsCount);
        }
    }
}