using String_Calculator_2._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator_2._1.Services
{
    public class Calculations : ICalculations
    {
        public int PerfomCalculation(List<int> numbersList)
        {
            var difference = 0;

            foreach (var number in numbersList)
            {
                difference -= Convert.ToInt32(number);
            }

            return difference;
        }
    }
}
