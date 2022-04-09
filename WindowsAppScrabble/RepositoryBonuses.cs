namespace WindowsAppScrabble
{
    using System.Collections.Generic;
    public class RepositoryBonuses
    {
        public Dictionary<int, List<int>> WordTriple = new Dictionary<int, List<int>>()
        {
            {0, new List<int>{0,7,14} },
            {7, new List<int>{0,14} },
            {14, new List<int>{0,7,14} }
        };

        public Dictionary<int, List<int>> WordDouble = new Dictionary<int, List<int>>()
        {
            {1, new List<int>{1,13} },
            {2, new List<int>{2,12} },
            {3, new List<int>{3,11} },
            {4, new List<int>{4,10} },

            {10, new List<int>{4,10} },
            {11, new List<int>{3,11} },
            {12, new List<int>{2,12} },
            {13, new List<int>{1,13} },
        };

        public Dictionary<int, List<int>> LetterTriple = new Dictionary<int, List<int>>()
        {
            {1, new List<int>{5,9} },
            {5, new List<int>{1,5,9,13} },
            {9, new List<int>{1,5,9,13} },
            {13, new List<int>{5,9} },
        };

        public Dictionary<int, List<int>> LetterDouble = new Dictionary<int, List<int>>()
        {
            {0, new List<int>{3,11} },
            {2, new List<int>{6,8} },
            {3, new List<int>{0,7,14} },
            {6, new List<int>{2,6,8,12} },

            {7, new List<int>{3,11} },

            {8, new List<int>{2,6,8,12} },
            {11, new List<int>{0,7,14} },
            {12, new List<int>{6,8} },
            {14, new List<int>{3,11} },
        };
    }
}
