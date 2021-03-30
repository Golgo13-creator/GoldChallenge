using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class CustomerRepo
    {
        protected readonly List<Customer> _customerDir = new List<Customer>();
        //create
        public bool AddCustomerToDir(Customer customer)
        {
            int StartingCount = _customerDir.Count;
            _customerDir.Add(customer);
            bool wasAdded = (_customerDir.Count > StartingCount) ? true : false;
            return wasAdded;
        }
        //read 
        public List<Customer> GetCustomer()
        {
            //order list ascending
            return _customerDir;
        }
        //read in alphabetical order
        public List<Customer> GetCustomerAlphabetically()
        {
            //order list ascending
            return _customerDir;
        }
        public Customer GetCustomerByFirstName(string firstName)
        {
            foreach(Customer customer in _customerDir)
            {
                if(customer.FirstName.ToLower() == firstName.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }
        //update
        public bool UpdateExistingCustomer(string originalName, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByFirstName(originalName);
            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.CustomerTypecast = newCustomer.CustomerTypecast;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteCustomer = _customerDir.Remove(existingCustomer);
            return deleteCustomer;
        }
        //may need to be sent to the programUI
        public void MessageToCustomer(Customer customer)
        {
            if (customer.CustomerTypecast == CustomerType.Potential)
            {
                Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
            }
            else if (customer.CustomerTypecast == CustomerType.Current)
            {
                Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            }
            else if (customer.CustomerTypecast == CustomerType.Past)
            {
                Console.WriteLine("It's been a long time since we've heard from you, we want you back.");
            }
        }
        
    }
}
