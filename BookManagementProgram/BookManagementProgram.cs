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

            List<BookInformation> bookList = new List<BookInformation>();
            List<CustomerInformation> customerList = new List<CustomerInformation>();
            UI ui = new UI();
            int seletedNumber = ExceptionHandling.wrongInput;
            

            while (true)
            {
                seletedNumber = ui.LogInOrCreateAccount();
                switch (seletedNumber)
                {
                    case User.logIn:
                        ui.LoginCustomer(customerList);
                        break;
                    case User.createAccount:
                        customerList.Add(ui.CreateCustomerAccount(customerList));
                        break;
                    default:
                        break;
                }
                if (seletedNumber == User.logIn)
                {
                    ui.LoginCustomer(customerList);
                }
            }

            
        }
    }
}
