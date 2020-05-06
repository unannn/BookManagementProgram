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

            List<BookInformation> bookList = new List<BookInformation>() {
                new BookInformation() //생성자 만들고 로그인 해보기
            };
            List<CustomerInformation> customerList = new List<CustomerInformation>();
            CustomerInformation logInCustomer;
            UI ui = new UI();
            int seletedNumber = ExceptionHandling.wrongInput;
            

            while (true)
            {
                seletedNumber = ui.LogInOrCreateAccount();
               
                if (seletedNumber == User.logIn)
                {
                    logInCustomer = ui.LoginCustomer(customerList);
                    if (logInCustomer == null) continue;
                }
                else if(seletedNumber == User.createAccount)
                {
                    customerList.Add(ui.CreateCustomerAccount(customerList));
                }
            }

            
        }
    }
}
