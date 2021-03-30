using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public enum CustomerType { Potential, Current, Past}
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerTypecast { get; set; }
        public string CustomerMessage
        {
            get
            {
                if (CustomerTypecast == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else if (CustomerTypecast == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (CustomerTypecast == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you, we want you back.";
                }
                return null;
            }
        }
        public Customer()
        {

        }
        public Customer(string firstName, string lastName, CustomerType customerTypecast)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerTypecast = customerTypecast;
            //potentially add msg here
        }
    }
}
