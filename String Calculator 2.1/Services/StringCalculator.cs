using String_Calculator_2._1.Interfaces;
using String_Calculator_2._1.Services;

namespace String_Calculator_2._1
{
    public class StringCalculator
    {
        private readonly ICalculations _calculator;
        private readonly ISplitNumber _split;
        private readonly IDelimiters _delimiters;
        private readonly INumbers _numbers;

        public StringCalculator(ICalculations calculator, IDelimiters delimiters, ISplitNumber split, INumbers numbers)
        { 
            _calculator = calculator;
            _delimiters = delimiters;
            _split = split;
            _numbers = numbers;
        }
        public int Subtract(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            return Calculations(numbers);
        }

        public int Calculations(string numbers)
        {
            var delimiters = _delimiters.GetDelimiters(numbers);
            var splitedNumbers = _split.SplitNumbers(numbers, delimiters);
            var numbersList = _numbers.ConvertStringNumbersToInt(splitedNumbers);
            var difference = _calculator.PerfomCalculation(numbersList);

            return difference;
        }
    }
}