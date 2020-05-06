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
            string yesOrNo = null;
             
            PrintInputBox("아이디");

            PrintInputBox("비밀번호");

            if (inputInspection == ExceptionHandling.wrongInput)
            {
                Console.WriteLine("가입하지 않은 아이디이거나, 잘못된 비밀번호입니다.");
                Console.Write("초기화면으로 돌아가시겠습니까?[y,n] ");
                //yesOrNo = ExceptionHandling.InputYesOrNo(yesOrNo);
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

        protected CustomerInformation InputCustomerAccountInformation(int passwordCheck,int duplicateId)
        {
            CustomerInformation newCustomer = new CustomerInformation();
            string id = null;
            string password = null, passwordConfirmation = null;
            string name = null;
            string phoneNumber = null;
            string adress = null;
            
            PrintInputBox("아이디");
            PrintInputBox("비밀번호");
            PrintInputBox("비밀번호확인");
            PrintInputBox("이름");
            PrintInputBox("휴대폰번호");
            PrintInputBox("주소");

            if (passwordCheck == ExceptionHandling.wrongInput) Console.WriteLine("비밀번호를 확인해 주세요");

            if (duplicateId == ExceptionHandling.wrongInput) Console.WriteLine("중복된 아이디가 있습니다");


            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 17 + passwordCheck + duplicateId);
            id = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            password = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            passwordConfirmation = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            name = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            phoneNumber = Console.ReadLine();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            adress = Console.ReadLine();

            if(string.Compare(password,passwordConfirmation) == 0)
            {
                return null;
            }

            newCustomer.Id = id;
            newCustomer.Password = password;
            newCustomer.Name = name;
            newCustomer.PhoneNumber = phoneNumber;
            newCustomer.Adress = adress;

            return newCustomer;
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
