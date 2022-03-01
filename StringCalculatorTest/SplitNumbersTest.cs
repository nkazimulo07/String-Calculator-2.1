using NUnit.Framework;
using String_Calculator_2._1.Services;
using System.Collections.Generic;

namespace StringCalculatorTest
{
   
    public class SplitNumbersTest
    {
        private SplitService _split;

        [SetUp]
        public void Setup()
        {
            _split = new SplitService();
        }
        
        [Test]
        public void WhenStringNumbers_UsingSplitNumbers_ResultsReturnNumbersArray()
        {
            //arrange
            const string input = "1,2";
            var delimiters = new List<string>() { ",", "\n" };
            string[] expected = { "1", "2" };

            //act
            var results = _split.SplitNumbers(input, delimiters);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
