using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public String FirstName
        {
            get; set;
        }

        public String LastName
        {
            get; set;
        }

        public String Address
        {
            get; set;
        }

        public String Postcode
        {
            get; set;
        }

        public String Country
        {
            get; set;
        }

        public string Phonenumber
        {
            get; set;
        }

        public String Email
        {
            get; set;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
