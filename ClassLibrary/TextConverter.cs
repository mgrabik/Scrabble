namespace ClassLibrary
{
    using System.Linq;
    public class TextConverter
    {
        public static int TextToNumber(string text)
        {
            return text
                .Select(c => c - 'A' + 1)
                .Aggregate((sum, next) => sum * 26 + next);
        }
    }
}
