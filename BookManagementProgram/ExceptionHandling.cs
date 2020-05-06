using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    static class ExceptionHandling
    {
        static public int InputNumber(uint  start, uint end, string numberInString)
        {
            int number;

            if (!string.IsNullOrEmpty(numberInString) && numberInString.Length == 1)
            {
                if (string.Compare(numberInString, start.ToString()) >= 0 && string.Compare(numberInString, end.ToString()) <= 0)
                {
                    number = int.Parse(numberInString);

                    return number;
                }                
            }

            Console.WriteLine("다시 입력해 주세요.");
            return -1;
        }

    }
}
