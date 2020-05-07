using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class CustomerInformation :ICloneable
    {
        private string id;
        private string password;
        private string name;
        private string phoneNumber;
        private string adress;
        private bool isAdministrator;
        private List<BookInformation> rentedBook;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public bool IsAdministrator
        {
            get { return isAdministrator; }
            set { isAdministrator = value; }
        }

        public CustomerInformation()
        {
            this.id = null;
            this.password = null;
            this.name = null;
            this.phoneNumber = null;
            this.adress = null;
            this.isAdministrator = false;
            this.rentedBook = new List<BookInformation>();
        }

        public CustomerInformation(string id, string password, string name, string phoneNumber, string adress,bool isAdministrator)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.adress = adress;
            this.isAdministrator = isAdministrator;
            this.rentedBook = new List<BookInformation>();
        }

        public object Clone()
        {
            CustomerInformation customer = new CustomerInformation();

            customer.id = this.id;
            customer.password = this.password;
            customer.name = this.name;
            customer.phoneNumber = this.phoneNumber;
            customer.adress = this.adress;
            customer.isAdministrator = this.isAdministrator;

            return customer;
        }
    }
    
}
