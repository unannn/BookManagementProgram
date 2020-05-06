using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookManagementProgram
    {
        public void StartProgram()
        {
            List<BookInformation> bookList = new List<BookInformation>();
            List<CustomerInformation> customerList = new List<CustomerInformation>();

            int Number = -1;
            string NumberStr;

            NumberStr = Console.ReadLine();

            if(!string.IsNullOrEmpty(NumberStr) && NumberStr.Length == 1)
            {
                if(string.Compare(NumberStr,"1") >= 0 && string.Compare(NumberStr, "9") <= 0)
                {
                    Number = int.Parse(NumberStr);
                    Console.WriteLine(Number);
                }
            }
            else
            {
                Console.WriteLine("NULL 입력");
            }
        }
    }
}
