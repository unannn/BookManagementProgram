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
            Console.WriteLine("     BOOK MANAGEMENT PROGRAM\n\n");
        }
       
        protected void InputIdAndPassword(ref string id, ref string password,int inputInspection)
        {
            string yesOrNo = null;
             
            PrintInputBox("아이디");

            PrintInputBox("비밀번호");

            if (inputInspection == ExceptionHandling.wrongInput)
            {
                Console.WriteLine("가입하지 않은 아이디이거나, 잘못된 비밀번호입니다.");
                Console.Write("초기화면으로 돌아가시겠습니까?[y,n] ");

                while (true)
                {
                    yesOrNo = Console.ReadLine();
                    string whiteSpace = new string(' ', 40);
                    if (yesOrNo == "y")
                    {
                        id = null;
                        password = null;
                        Console.Clear();
                        return;
                    }
                    else if (yesOrNo == "n")
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        Console.WriteLine(whiteSpace);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(36, Console.CursorTop - 1 );
                        Console.WriteLine(whiteSpace);
                        Console.SetCursorPosition(36, Console.CursorTop - 1);
                    }
                }
               
            }

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 5 + inputInspection);
            id = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            password = Console.ReadLine();                       
        }
              
        protected void PrintInputBox(string inputData)
        {
            string loginBar = new String('-', 30);
            string whiteSpace = new String(' ', 50 );

            Console.WriteLine(loginBar);
            Console.Write("  {0} ", inputData);
            Console.Write(whiteSpace);
            Console.WriteLine();
            Console.WriteLine(loginBar);
        }

        protected void PrintMenuList(List<string> menuList)
        {
            Console.WriteLine();
            foreach(string item in menuList)
            {
                Console.WriteLine(item + "\n");
            }
        }
    }
}
