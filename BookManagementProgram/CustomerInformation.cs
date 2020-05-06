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

        public object Clone()
        {
            CustomerInformation customer = new CustomerInformation();

            customer.id = this.id;
            customer.password = this.password;
            customer.name = this.name;
            customer.phoneNumber = this.phoneNumber;
            customer.adress = this.adress;

            return customer;
        }

        //게터세터, 생성자       
    }
    
}
