using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class CustomerInformation
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

        //게터세터, 생성자       
    }
    
}
