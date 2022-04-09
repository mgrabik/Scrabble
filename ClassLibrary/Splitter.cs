namespace ClassLibrary
{
    using System.Collections.Generic;
    public class Splitter
    {
        public static List<char> Spliting(string word)
        {
            List<char> Splited = new List<char>();
            foreach (char letter in word)
            {
                Splited.Add(letter);
            }
            return Splited;
        }
    }
}
