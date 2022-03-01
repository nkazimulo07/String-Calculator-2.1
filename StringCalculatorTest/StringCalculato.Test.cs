using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._1;
using String_Calculator_2._1.Interfaces;
using System.Collections.Generic;

namespace StringCalculatorTest
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;
        private ICalculations _calculationsMock;
        private  ISplitNumber _splitNumberMock;
        private IDelimiters _delimitersMock;
        private  INumbers _numbersMock;

        [SetUp]
        public void Setup()
        {
            _calculationsMock = Substitute.For<ICalculations>();
            _numbersMock = Substitute.For<INumbers>();
            _splitNumberMock = Substitute.For<ISplitNumber>();
            _delimitersMock = Substitute.For<IDelimiters>();
            _stringCalculator = new StringCalculator(_calculationsMock, _delimitersMock, _splitNumberMock, _numbersMock);
        }

        [Test]
        public void WhenEmptyString_UsingSubtract_ResultsReturnsZero()
        {
            //arrange
            const string input = "";
            const int expected = 0;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithOneNumber_UsingSubract_ResultsReturnsDiffence()
        {
            //arrange
            const string input = "1";
            const int expected = -1;
            var delimitersList = new List<string> { ",", "\n" };
            string[] numbersStringArray = { "1" };
            var numbersList = new List<int>() { 1 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitNumberMock.SplitNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerfomCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);
            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithTwoNumbers_UsingSubtract_ResultsReturnsDifference()
        {
            //arrange 
            const string input = "1,2";
            const int expected = -3;
            var delimitersList = new List<string> { ",", "\n" };
            string[] numbersStringArray = { "1" , "2" };
            var numbersList = new List<int>() { 1,2 };

            //act
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitNumberMock.SplitNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerfomCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);            

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithTwoNumbersSeperatedByNewLine_UsingSubtract_ResultsReturnsDifference()
        {
            //arrange 
            const string input = "3\n3";
            const int expected = -6;
            var delimitersList = new List<string> { ",", "\n" };
            string[] numbersStringArray = { "3", "3" };
            var numbersList = new List<int>() { 3, 3 };

            //act
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitNumberMock.SplitNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerfomCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithTwoNumbersAndCustomDelimiter_UsingSubtract_ResultsReturnsDifference()
        {
            //arrange 
            const string input = "##;\n1;2";
            const int expected = -3;
            var delimitersList = new List<string> { ",", "\n", ";" };
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            //act
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitNumberMock.SplitNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerfomCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithThreeNumbersAndCustomDelimiterStartingWithFlag_UsingSubtract_ResultsReturnsDifference()
        {
            //arrange 
            const string input = "<<>>##<$$$><###>\n5$$$6###7";
            const int expected = -15;
            var delimitersList = new List<string> { ",", "\n", "$$$", "###" };
            string[] numbersStringArray = { "5", "6", "7" };
            var numbersList = new List<int>() { 5, 6, 7 };

            //act
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitNumberMock.SplitNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerfomCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}