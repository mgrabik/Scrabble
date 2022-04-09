namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    public class WordsFinder
    {
        public static string noWords = "No words was find";

        // New finder uses binary search --> O(logN)
        public static string Find(string SearchingWord, List<string> AllWords)
        {
            string result = WordsFinder.noWords;
            int min = 0;
            int max = AllWords.Count - 1;

            while(min <= max)
            {
                int mid = (min + max) / 2;
                switch(check(SearchingWord, AllWords[mid]))
                {
                    case 0:
                        min = mid + 1;
                        break;
                    case 1:
                        max = mid - 1;
                        break;
                    case 2:
                        result = SearchingWord;
                        goto End;
                    case 3:
                        result = WordsFinder.noWords;
                        goto End;
                }
            }
            End:
            return result;
        }

        private static int check(string searchingWord, string comparedWord)
        {
            int len1 = searchingWord.Length;
            int len2 = comparedWord.Length;
            int max = Math.Min(len1, len2);
            if(searchingWord == comparedWord)
            {
                return 2;
            }
            for(int i = 1; i < max; i++)
            {
                if (char.ToUpper(searchingWord[i]) > char.ToUpper(comparedWord[i]))
                {
                    return 0;    // searchingWord is higher
                }
                if (char.ToUpper(searchingWord[i]) < char.ToUpper(comparedWord[i]))
                {
                    return 1;   // searchingWord is lower
                }
                if(char.ToUpper(searchingWord[i]) == char.ToUpper(comparedWord[i]))
                {
                    continue;
                }
            }
            return len1 < len2 ? 1 : 0; 
        }

        public static bool CheckWord(string wordToCheck)
        {
            var index = TextConverter.TextToNumber(wordToCheck[0].ToString());

            string finded = WordsFinder.Find(wordToCheck, WordsReader.AllWords[index - 1]);

            if (finded == WordsFinder.noWords)
            {
                return false;
            }
            return true;
        }
    }
}
