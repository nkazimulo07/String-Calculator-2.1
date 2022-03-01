using String_Calculator_2._1.Interfaces;

namespace String_Calculator_2._1.Services
{
    public class Calculations : ICalculations
    {
        public int PerfomCalculation(List<int> numbersList)
        {
            var difference = 0;

            foreach (var number in numbersList)
            {
                difference -= number;
            }

            return difference;
        }
    }
}
