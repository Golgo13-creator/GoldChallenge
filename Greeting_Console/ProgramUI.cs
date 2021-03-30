using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class ProgramUI
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
        public void Run()
        {
            SeedCustomers();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter an option selection number:\n" +
                    "1. Add a new customer\n" +
                    "2. Show all customers\n" +
                    "3. Update existing customers\n" +
                    "4. Delete customer\n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        ShowAllCustomers();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number\n" +
                            "Press any key to continue");
                        break;
                }
                Console.ReadKey();
            }
        }
        private void CreateCustomer()
        {
            Console.Clear();
            Customer customer = new Customer();
            Console.WriteLine("Welcome to the Create Customer Page");
            Console.WriteLine("Please enter a first name:");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name:");
            Console.WriteLine("Please select a customer type\n" +
                "1: Potential\n" +
                "2: Current\n" +
                "3: Past");
            string CustomerTypes = Console.ReadLine();
            switch(CustomerTypes)
            {
                case "1":
                    customer.CustomerTypecast = CustomerType.Potential;
                    break;
                case "2":
                    customer.CustomerTypecast = CustomerType.Current;
                    break;
                case "3":
                    customer.CustomerTypecast = CustomerType.Past;
                    break;
                default:
                    Console.WriteLine("Please enter a valid value");
                    break;
            }
        }
        private void ShowAllCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _customerRepo.GetCustomer();
            foreach(Customer customer in listOfCustomers)
            {
                Console.WriteLine($"First Name: {customer.FirstName}\n" +
                    $"Last Name: {customer.LastName}\n" +
                    $"Customer Type: {customer.CustomerTypecast}\n" +
                    $"Email: {customer.CustomerMessage}");
            }
        }
        private void UpdateCustomer()
        {
            Console.Clear();

        }
        private void DeleteCustomer()
        {
            Console.ReadLine();
            Console.WriteLine("Which customer would you like to remove?\n" +
                "Enter their first name");
            List<Customer> customerList = _customerRepo.GetCustomer();
            int count = 0;
            foreach(Customer customer in customerList)
            {
                count++;
                Console.WriteLine($"{count}. {customer.FirstName} {customer.LastName}");
            }
            string targetName = Console.ReadLine();
            Customer customer1 = new Customer();
            if(targetName.ToLower() == customer1.FirstName.ToLower())
            {
                if(_customerRepo.DeleteExistingCustomer(customer1))
                {
                    Console.WriteLine($"{customer1.FirstName} {customer1.LastName} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("We were unable to remove this customer.");
                }
            }
            else
            {
                Console.WriteLine("No customer has that name");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedCustomers()
        {
            Customer ye = new Customer("Kanye", "West", CustomerType.Current);
            Customer fredo = new Customer("Freddie", "Gibbs", CustomerType.Current);
            Customer doom = new Customer("Daniel", "Dumile", CustomerType.Past);

            _customerRepo.AddCustomerToDir(ye);
            _customerRepo.AddCustomerToDir(fredo);
            _customerRepo.AddCustomerToDir(doom);
        }
    }
}
