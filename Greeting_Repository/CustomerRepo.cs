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
        //read  in alphabetical order
        public List<Customer> GetCustomer()
        {
            //order list ascending
            return _customerDir;
        }
        //helper
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
        public bool DeleteExistingCustomer(string existingCustomer)
        {
            Customer customer = GetCustomerByFirstName(existingCustomer);
            if(customer == null)
            {
                return false;
            }
            int initialCount = _customerDir.Count;
            _customerDir.Remove(customer);
            if(initialCount > _customerDir.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
