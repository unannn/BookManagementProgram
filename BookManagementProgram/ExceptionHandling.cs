using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
   
    static class ExceptionHandling
    {
        public const int wrongInput = -1;

        static public int InputNumber(int  start, int end, string numberInString)   //start 와 end 사이에 문자열이 입력되면 정수로 변환 후 반환 실패시 -1 반환
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

            return wrongInput;
        }
    }
}
