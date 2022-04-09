namespace ClassLibrary
{
    using System.IO;
    using System.Collections.Generic;

    public class WordsReader
    {
        public static List<List<string>> AllWords = new List<List<string>>();
        string path = @"..\..\..\..\ClassLibrary\WordsRepository\";

        private string[] filename = new string[26] {"A.txt","B.txt","C.txt","D.txt", "E.txt", "F.txt",
        "G.txt","H.txt","I.txt","J.txt","K.txt","L.txt","M.txt","N.txt","O.txt","P.txt","Q.txt","R.txt",
            "S.txt","T.txt","U.txt","V.txt","W.txt","X.txt","Y.txt","Z.txt",};

        public WordsReader() { }

        public void Words()
        {
            for(int i = 0; i < 26; i++)
            {
                string[] lines = File.ReadAllLines(path + filename[i]);
                List<string> templist = new List<string>();
                foreach (string e in lines)
                {
                    templist.Add(e);
                }
                AllWords.Add(templist);
            }
        }
    }
}
