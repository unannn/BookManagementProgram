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

        protected void InputIdAndPassword(ref string id, ref string password,int inputInspection)
        {            
            PrintInputBox("아이디");

            PrintInputBox("비밀번호");

            if (inputInspection == ExceptionHandling.wrongInput)
            {
                Console.WriteLine("가입하지 않은 아이디이거나, 잘못된 비밀번호입니다.");
            }

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 5);
            id = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            password = Console.ReadLine();

                       
        }

        protected List<CustomerInformation> CreateID(List<CustomerInformation> customerList)
        {

            return customerList;
        }

        private void PrintInputBox(string inputData)
        {
            string loginBar = new String('-', 30);
            string whiteSpace = new String(' ', 26 - inputData.Length * 2);

            Console.WriteLine(loginBar);
            Console.Write("  {0} ", inputData);
            Console.Write(whiteSpace);
            // Console.WriteLine("|");
            Console.WriteLine();

            //Console.Write(" ");
            Console.WriteLine(loginBar);
        }
    }
}
