namespace ClassLibrary
{
    public class Counter
    {
        public static int Points(string word)
        {
            int points = 0;

            foreach (char x in Splitter.Spliting(word))
            {
                points += ListofPoints.LetterPoints[x.ToString()];
            }

            return points;
        }

    }
}
