using System.Collections.Generic;
using System.Linq;
using Pocker.Cards;

namespace Pocker.Hands
{
    public static class HandRankCalculator
    {
        /// <summary>
        /// Роял флеш - стрит-флеш со старшей картой Туз
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsRoyalFlush(IEnumerable<CardBase> cards)
        {
            return cards.OrderBy(x => x.Rank).Last().Rank == Rank.Ace && IsStraightFlush(cards);
        }
        
        /// <summary>
        /// Стрит-флеш - 5 карт одной масти
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsStraightFlush(IEnumerable<CardBase> cards)
        {
            return IsFlush(cards) && IsStraight(cards);
        }

        /// <summary>
        /// Каре - 4 карты одного уровня
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsFourOfAKind(IEnumerable<CardBase> cards)
        {
            return cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4);
        }
        
        /// <summary>
        /// Фулл хаус - сет и пара одновременно
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsFullHouse(IEnumerable<CardBase> cards)
        {
            return IsThreeOfAKind(cards) && IsPair(cards);
        }
        
        /// <summary>
        /// Флеш - 5 карт одной масти
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsFlush(IEnumerable<CardBase> cards)
        {
            return cards.GroupBy(x => x.Suit).Any(x => x.Count() == 5);
        }
        /// <summary>
        /// Стрит - последовательность из 5 карт по возрастанию или убыванию
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsStraight(IEnumerable<CardBase> cards)
        {
            bool checkStraight(IEnumerable<CardBase> possible)
            {
                return possible.GroupBy(c => c.Rank).Count() == possible.Count() && possible.Max(c => (int)c.Rank) - possible.Min(c => (int)c.Rank) == 4;
            }
            
            var ordered = cards.OrderByDescending(a => a.Rank).ToList();
            for (var i = 0; i < ordered.Count - 4; i++)
            {
                var skipped = ordered.Skip(i);
                var possibleStraight = skipped.Take(5).ToList();
                if (IsStraight(possibleStraight))
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Сет - три карты с одинаковым уровнем (222)
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsThreeOfAKind(IEnumerable<CardBase> cards)
        {
            return cards.GroupBy(x => x.Rank).Any(x => x.Count() >= 3);
        }
        
        /// <summary>
        /// Две пары - две пары карты  с одинаковым уровнем (прим. QQ и 88)
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsTwoPair(IEnumerable<CardBase> cards)
        {
            return cards.GroupBy(x => x.Rank).Count(x => x.Count() >= 2) >= 2;
        }
        /// <summary>
        /// Пара - две карты с одинаковым уровнем (88)
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool IsPair(IEnumerable<CardBase> cards)
        {
            return cards.GroupBy(x => x.Rank).Any(x => x.Count() >= 2);
        }
        
        public static HandRank Calculate(IEnumerable<CardBase> cards)
        {
            if (IsRoyalFlush(cards))
                return HandRank.RoyalFlush;
            if (IsStraightFlush(cards))
                return HandRank.StraightFlush;
            if (IsFourOfAKind(cards))
                return HandRank.FourOfAKind;
            if (IsFullHouse(cards))
                return HandRank.FullHouse;
            if (IsFlush(cards))
                return HandRank.Flush;
            if (IsStraight(cards))
                return HandRank.Straight;
            if (IsThreeOfAKind(cards))
                return HandRank.ThreeOfAKind;
            if (IsTwoPair(cards))
                return HandRank.TwoPair;
            if (IsPair(cards))
                return HandRank.Pair;

            return HandRank.HighCard;
        }
    }
}