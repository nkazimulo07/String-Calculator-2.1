using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator_2._1.Interfaces
{
    public interface INumbers
    {
        List<int> ConvertStringNumbersToInt(string[] numbers);
        void CheckNumbersBiggerThanOneThousand(List<int> numbersList);
    }
}
