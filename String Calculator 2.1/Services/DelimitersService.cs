using String_Calculator_2._1.Interfaces;

namespace String_Calculator_2._1.Services
{
    public class DelimitersService : IDelimiters
    {
        const string HashTags = "##";
        const string NewLine = "\n";
        const char LeftSqureBracket = '[';
        const char RightSqureBracket = ']';
        const string SquareBrackets = "][";
        const char Flag = '<';

        public List<string> GetDelimiters(string numbers)
        {
            List<string> delimiters = new List<string>() { ",", "\n" };

            if (numbers.StartsWith(HashTags))
            {
                var customDelimiter = CustomDelimiter(numbers);
                delimiters.AddRange(customDelimiter);
            }
            else if (numbers.StartsWith(Flag))
            {
                delimiters.AddRange(FlaggedDelimiter(numbers));
            }

            return delimiters;
        }

        public List<string> MultipleDelimiters(string delimiters)
        {
            char[] charsToTrim = { LeftSqureBracket, RightSqureBracket };
            string cleanDelimiter = delimiters.Trim(charsToTrim);
            string[] multipleDelimiter = cleanDelimiter.Split(new string[] { SquareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return multipleDelimiter.ToList();
        }

        public List<string> FlaggedDelimiter(string number)
        {
            var customStartingPoint = number.IndexOf(HashTags) + 2;
            var customEndingPoint = number.IndexOf(NewLine) - 6;
            var delimiter = number.Substring(customStartingPoint, customEndingPoint);
            char leftseperator = number[1];
            char rightseperator = number[number.IndexOf(HashTags) - 1];
            char[] charsToTrim = { leftseperator, rightseperator };
            string cleanDelimiter = delimiter.Trim(charsToTrim);

            return  cleanDelimiter.Split(new string[] { rightseperator.ToString(), leftseperator.ToString() }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public List<string> CustomDelimiter(string numbers)
        {
            var delimiter = numbers.Substring(2, numbers.IndexOf(NewLine) - 2);
            List<string> delimiters = new List<string>();

            if (delimiter.StartsWith(LeftSqureBracket) && delimiter.EndsWith(RightSqureBracket))
            {
                var multipleDelimiter = MultipleDelimiters(delimiter);
                delimiters.AddRange(multipleDelimiter);
            }
            else
            {
                delimiters.Add(delimiter);
            }

            return delimiters;
        }
    }
}
