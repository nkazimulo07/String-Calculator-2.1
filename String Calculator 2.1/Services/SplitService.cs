namespace String_Calculator_2._1.Services
{
    public class SplitService
    {
        const string HashTags = "##";
        public string[] SplitNumbers(string numbers, List<string> delimiters)
        {
            if (numbers.Contains(HashTags))
            {
                numbers = numbers.Substring(numbers.LastIndexOf('\n') + 1);
            } 

            string[] numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

            return numbersArray;
        }
    }
}
