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

    class UI : CustomerManagement
    {

        public int LogInOrCreateAccount()
        {
            string inputNumberInString = null;
            int inputNumber = -2;
            List<string> initialMenu = new List<string>()
            {
                "로그인 1",
                "회원가입 2"
            };

            while(inputNumber < 0)
            {
                PrintTitle();


                Console.Write($"{initialMenu[0]} {initialMenu[1]} 입력 : ");
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
            CustomerInformation customerToBeAdded = new CustomerInformation();
            NewAccountException newAccountException = new NewAccountException();

            bool loginSucessful = false;

            while (!loginSucessful)
            {
                Console.Clear();

                PrintTitle();
                
                customerToBeAdded = InputCustomerAccountInformation(newAccountException);

                if (newAccountException.previousOrStay == "stay")
                {
                    newAccountException.previousOrStay = " ";

                    continue;
                }
                else if (newAccountException.previousOrStay == "previous")
                {
                    newAccountException.previousOrStay = " ";
                    Console.Clear();
                    return null;
                }
                
                foreach(CustomerInformation customer in customerList)
                {
                    if (string.Compare(customerToBeAdded.Id, customer.Id) == 0)  //같은 아이디 존재
                    {
                        newAccountException.sameId = true;
                        continue;
                    }
                }

                if (customerToBeAdded.Id == null)
                {
                    newAccountException.wrongId = true;
                    continue;
                }

                if (customerToBeAdded.Password == null)
                {
                    newAccountException.wrongPassword = true;
                    continue;
                }

                if (customerToBeAdded.Name == null)
                {
                    newAccountException.wrongName = true;
                    continue;
                }

                if(customerToBeAdded.PhoneNumber == null)
                {
                    newAccountException.wrongPhoneNumber = true;
                    continue;
                }

                if (customerToBeAdded.Adress == null)
                {
                    newAccountException.wrongAdress = true;
                    continue;
                }

                loginSucessful = true;

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
