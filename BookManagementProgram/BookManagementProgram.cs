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
            List<BookInformation> bookList = new List<BookInformation>();
            List<CustomerInformation> customerList = new List<CustomerInformation>();
            UI ui = new UI();

            if (ui.LogInOrCreateAccount() == 1) ui.LoginCustomer(customerList);
            

            while (true)
            {
            }

            
        }
    }
}
