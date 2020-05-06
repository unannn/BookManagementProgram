using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class UITooI
    {
        protected void PrintTitle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("BOOK MANAGEMENT PROGRAM\n\n");
        }

        protected void InputIdAndPassword(ref string id, ref string password)
        {            
            PrintInputBox("아이디");

            PrintInputBox("비밀번호");

            Console.SetCursorPosition(2, 1);
            id = Console.ReadLine();

            Console.SetCursorPosition(2, 1 + 3);
            password = Console.ReadLine();

                       
        }

        private void PrintInputBox(string inputData)
        {
            string loginBar = new String('-', 30);
            string whiteSpace = new String(' ', 26 - inputData.Length * 2);
           // Console.Write(" ");
           // Console.Write("┌");
            Console.WriteLine(loginBar);
            Console.Write("  {0} ",inputData);
            Console.Write(whiteSpace);
            // Console.WriteLine("|");
            Console.WriteLine();

            //Console.Write(" ");
            Console.WriteLine(loginBar);
        }

        protected List<CustomerInformation> CreateID(List<CustomerInformation> customerList)
        {

            return customerList;
        }
    }
}
