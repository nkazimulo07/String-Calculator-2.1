using String_Calculator_2._1.Interfaces;

namespace String_Calculator_2._1.Services
{
    public class SplitService
    {
        private IDelimiters _delimiters;
        public SplitService(IDelimiters delimiters)
        {
            _delimiters = delimiters;
        }

        const string HashTags = "##";
        public string[] SplitNumbers(string numbers)
        {
            var delimiters = _delimiters.GetDelimiters(numbers);

            if (numbers.Contains(HashTags))
            {
                numbers = numbers.Substring(numbers.LastIndexOf('\n') + 1);
            }

            return numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

        }
    }
}
