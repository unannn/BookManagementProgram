using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class CustomerManagement : UITooI
    {
        //public List<CustomerInformation> ResisterCustomer(List<CustomerInformation> customerList)
        //{
        //    //

        //    return customerList;
        //}

        protected CustomerInformation InputCustomerAccountInformation(NewAccountException newAccountException)
        {
            CustomerInformation newCustomer = new CustomerInformation();
            string id = null;
            string password = null, passwordConfirmation = null;
            string name = null;
            string phoneNumber = null;
            string adress = null;
            string whiteSpace = new String(' ', 50);
            string yesOrNo = null;
            int exceptionNumber = 0;

            Console.WriteLine("아이디 (2~11글자)");

            PrintInputBox("");
            PrintInputBox("비밀번호(2~11글자)");
            PrintInputBox("비밀번호확인 (2~11글자)");
            PrintInputBox("이름 1~20글자 (2~11글자)");
            PrintInputBox("휴대폰번호('-'없이 11글자)");
            PrintInputBox("주소 1~20글자");

            if(newAccountException.sameId == true)
            {
                Console.WriteLine("아이디가 이미 존재 합니다.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            else if (newAccountException.wrongId == true)
            {
                Console.WriteLine("아이디를 다시 입력해주세요.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            else if (newAccountException.wrongPassword == true)
            {
                Console.WriteLine("비밀번호를 다시 입력해주세요.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            else if (newAccountException.wrongName == true)
            {
                Console.WriteLine("이름을 다시 입력해주세요.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            else if (newAccountException.wrongPhoneNumber == true)
            {
                Console.WriteLine("휴대번호를 다시 입력해주세요.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            else if (newAccountException.wrongAdress == true)
            {
                Console.WriteLine("주소를 다시 입력해주세요.");
                newAccountException.initialize(false);
                exceptionNumber = 1;
            }
            
            if(exceptionNumber == 1)
            {
                Console.Write("초기화면으로 돌아가시겠습니까?[y,n] ");
                yesOrNo = ExceptionHandling.InputString(1, 1);
                if(yesOrNo != null)
                {
                    if (yesOrNo == "y") newAccountException.previousOrStay = "previous";
                    else if(yesOrNo == "n")newAccountException.previousOrStay = "stay";                   
                }

                return newCustomer;
            }


            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 17 - exceptionNumber);

            id = ExceptionHandling.InputId();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            Console.Write(whiteSpace);
            Console.SetCursorPosition(2, Console.CursorTop);
            password = ExceptionHandling.InputPassword();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            Console.Write(whiteSpace);
            Console.SetCursorPosition(2, Console.CursorTop);
            passwordConfirmation = ExceptionHandling.InputPassword();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            Console.Write(whiteSpace);
            Console.SetCursorPosition(2, Console.CursorTop);
            name = ExceptionHandling.InputString(2, 20);

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            Console.Write(whiteSpace);
            Console.SetCursorPosition(2, Console.CursorTop);
            phoneNumber = ExceptionHandling.InputPhoneNumber();

            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
            Console.Write(whiteSpace);
            Console.SetCursorPosition(2, Console.CursorTop);
            adress = ExceptionHandling.InputString(1, 30);

            newCustomer.Id = id;
            newCustomer.Password = password;
            newCustomer.Name = name;
            newCustomer.PhoneNumber = phoneNumber;
            newCustomer.Adress = adress;

            return newCustomer;
        }
        public string ModifyAdress(string adress)
        {
            string ModifiedAdress = null;


            return ModifiedAdress;
        }

        public string ModifyPhoneNumber(string phoneNumber)
        {
            string ModifiedPhoneNumber = null;

            return ModifiedPhoneNumber;
        }

        public List<CustomerInformation> DeleteCustomerData(List<CustomerInformation> custmerList)
        {

            return custmerList;
        }

        public List<CustomerInformation> SerchCustomer(List<CustomerInformation> customer,string serchString)
        {
            List<CustomerInformation> serchedCustomers = new List<CustomerInformation>();

            return  serchedCustomers;
        }
        public void PrintAllCustomer(List<CustomerInformation> customerList)
        {

        }
    }
}
