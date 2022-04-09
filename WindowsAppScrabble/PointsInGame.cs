namespace WindowsAppScrabble
{
    public class PointsInGame
    {
        public static int AmountOfPlayers { get; set; }
        public static int[] PlayerPoints = new int[4];
        public static int currentPlayer { get; set; }

        public static void Reset()
        {
            PlayerPoints[0] = 0;
            PlayerPoints[1] = 0;
            PlayerPoints[2] = 0;
            PlayerPoints[3] = 0;
            currentPlayer = 1;
        }

        public static void NextPlayer()
        {
            if (currentPlayer == AmountOfPlayers)
            {
                currentPlayer =  1;
            }
            else
            {
                currentPlayer++;
            }
        }
    }
}
