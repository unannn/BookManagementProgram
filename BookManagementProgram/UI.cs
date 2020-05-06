using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class InputNumberRange
    {
        public const int startNumber = 1;
        public const int inputLocationX = 28;
        public const int inputLocationY = 5;
    }
    class User
    {
        public const int logIn = 1;
        public const int createAccount = 2;

    }

    class UI : UITooI
    {

        public int LogInOrCreateAccount()
        {
            string inputNumberInString = null;
            int inputNumber = -2;
            List<string> initialMenu = new List<string>()
            {
                "1. 로그인",
                "2. 회원가입"
            };

            while(inputNumber < 0)
            {
                PrintTitle();


                Console.Write("로그인 1, 회원가입 2 입력 : ");
                if(inputNumber == ExceptionHandling.wrongInput)Console.Write("\n다시 입력해 주세요.");

                Console.SetCursorPosition(InputNumberRange.inputLocationX, InputNumberRange.inputLocationY);
                inputNumberInString = Console.ReadLine();

                inputNumber = ExceptionHandling.InputNumber(InputNumberRange.startNumber, initialMenu.Count, inputNumberInString);

                Console.Clear();
            }

            return inputNumber;
        }
        
        public CustomerInformation LoginCustomer(List<CustomerInformation> customerList)
        {
            string id = null;
            string password = null;
            CustomerInformation loginCustomer = null;
            int inputInspection = 0;

            while (loginCustomer == null)
            {
                PrintTitle();


                InputIdAndPassword(ref id, ref password, inputInspection);

                if (id == null && password == null) return null;

                foreach(CustomerInformation customer in customerList)
                {
                    if(customer.Id == id && customer.Password == password)
                    {
                        loginCustomer = (CustomerInformation)customer.Clone();  //깊은복사
                    }
                }

                inputInspection = -1;
                Console.Clear();
            }
            
            return loginCustomer;
        }

        public CustomerInformation CreateCustomerAccount(List<CustomerInformation> customerList)
        {
            CustomerInformation customerToBeAdded = null;
            bool sameId = true;
            int customerNumber;
            int passwordCheck = 0,duplicateId = 0;

            while (sameId)
            {
                PrintTitle();

                customerToBeAdded = InputCustomerAccountInformation(passwordCheck,duplicateId);


                if(customerToBeAdded != null)
                {                   
                    for(customerNumber  = 0; customerNumber < customerList.Count; customerNumber++)
                    {
                        if(string.Compare(customerToBeAdded.Id,customerList[customerNumber].Id) == 0)
                        {
                            duplicateId = ExceptionHandling.wrongInput;
                            break;
                        }
                    }

                    if(customerNumber == customerList.Count) // 위 반복문을 모두 수행했는데 break가 안됐으면
                    {
                        sameId = false;
                    }
                }
                else
                {
                    passwordCheck = ExceptionHandling.wrongInput;
                }
                Console.Clear();
            }

            return customerToBeAdded;
        }
          
        public int PrintUGeneralUserMenu()
        {
            List<string> Menu = new List<string>(){                 
               "1. 도서 대여",
               "2. 회원 정보 수정",
               "3. 로그아웃"
            };

            

            return 1;
        }

        public int PrintAdministratorUserMenu()
        {
           
            List<string> Menu = new List<string>(){
               "1. 도서 대여",
               "2. 회원 정보 수정",
               "3. 도서 정보 수정",
               "3. 로그아웃"
            };
            return 1;
        }
    }
}
