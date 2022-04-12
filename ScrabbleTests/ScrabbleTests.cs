namespace ScrabbleTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ClassLibrary;
    using System;

    [TestClass]
    public class ScrabbleTests
    {
        [DataTestMethod]
        [DataRow("KASQUGHBTIZ")]
        public void DurationOfGetCombinationsMethod(string letters)
        {
            Action action = () => AllCombinations.GetCombinations(letters);
        }
    }
}
