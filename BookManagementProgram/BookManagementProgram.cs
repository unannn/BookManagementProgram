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
            Console.Title = "BookManagementProgram";
            Console.SetWindowSize(70,36);

            List<BookInformation> bookList = new List<BookInformation>() {
            };
            List<CustomerInformation> customerList = new List<CustomerInformation>()
            {
                new CustomerInformation("digh7930","16011679","이윤환","01049075608","서울시 도봉구 방학3동 신동아아파트") //생성자 만들고 로그인 해보기
            };
            CustomerInformation logInCustomer, createdAccount;
            UI ui = new UI();
            int seletedNumber = ExceptionHandling.wrongInput;
            

            while (true)
            {
                seletedNumber = ui.LogInOrCreateAccount();
               
                if (seletedNumber == User.logIn)
                {
                    logInCustomer = ui.LoginCustomer(customerList); //뒤로가기

                    if (logInCustomer == null) continue;
                }
                else if(seletedNumber == User.createAccount)
                {
                    createdAccount = ui.CreateCustomerAccount(customerList);

                    if (createdAccount == null) continue;  //뒤로가기

                    customerList.Add(createdAccount);
                }
            }

            
        }
    }
}
