namespace ClassLibrary
{
    using System.Collections.Generic;
    public class AllCombinations
    {
        public static List<string> combinations = new List<string> { string.Empty };

        public static IEnumerable<string> GetCombinations(IEnumerable<char> word)
        {
            foreach (var item in word)
            {
                var newCombinations = new List<string>();

                foreach (var combination in combinations)
                {
                    for (var i = 0; i <= combination.Length; i++)
                    {
                        newCombinations.Add(
                          combination.Substring(0, i) +
                          item +
                          combination.Substring(i));
                    }
                }

                combinations.AddRange(newCombinations);
            }
            combinations.Remove("");

            return combinations;
        }
    }
}
