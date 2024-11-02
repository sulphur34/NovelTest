using System;
using System.Collections.Generic;

namespace MemoryGame
{
    public static class ListExtensions
    {
        private static readonly Random _random = new ();

        public static void Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            for (var i = n - 1; i > 0; i--)
            {
                var j = _random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}