using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._1.Interfaces;
using String_Calculator_2._1.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTest
{
    public class NumbersTest
    {
        private Numbers _numbers;
        private IErrorHandling _errorHandlingMock;

        [SetUp]
        public void Setup()
        {
            _errorHandlingMock = Substitute.For<IErrorHandling>();
            _numbers = new Numbers(_errorHandlingMock);
        }

        [Test]
        public void WhenStringWithNegativeNumbers_UsingNumbersBiggerThanOneThousand_ResultsReturnsException()
        {
            // arrange
            var input = new List<int> { 1000, 2000, 6000 };

            //act
            _errorHandlingMock.When(x => x.ThrowException(Arg.Any<string>())).Do(x => throw new Exception("You can't subtract numbers greater than 1000 : 1000 2000 6000 "));
            var results = Assert.Throws<System.Exception>(() => _numbers.CheckNumbersBiggerThanOneThousand(input));

            //assert
            Assert.AreEqual("You can't subtract numbers greater than 1000 : 1000 2000 6000 ", results.Message);
        }

        [Test]
        public void WhenCharacter_UsingConvertCharacterToNumber_ResultsReturnsInt()
        {
            // arrange
            char input = 'j';
            var expected = 9;

            //act
            var results = _numbers.ConvertCharacterToInt(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithLetters_UsingConvertStringToInt_ResultsReturnList()
        {
            //arrrange
            string[] input = { "a", "b", "c" };
            var expected = new List<int> { 0, 1, 2 };

            //act
            var results = _numbers.ConvertStringNumbersToInt(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
