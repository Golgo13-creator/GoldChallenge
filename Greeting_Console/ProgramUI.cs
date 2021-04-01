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
                Console.WriteLine("Welcome to the Customer Menu\n\nEnter an option selection number:\n\n" +
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
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to exit");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();
            Console.WriteLine("Welcome to the Create Customer Page\n");
            Console.WriteLine("Please enter a first name:");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name:");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Please select a customer type by number\n" +
                "1: Potential\n" +
                "2: Current\n" +
                "3: Past");
            string customerTypes = Console.ReadLine();
            switch(customerTypes)
            {
                case "1":
                    newCustomer.CustomerTypecast = CustomerType.Potential;
                    break;
                case "2":
                    newCustomer.CustomerTypecast = CustomerType.Current;
                    break;
                case "3":
                    newCustomer.CustomerTypecast = CustomerType.Past;
                    break;
                default:
                    Console.WriteLine("Please enter a valid value");
                    break;
            }
            _customerRepo.AddCustomerToDir(newCustomer);
        }
        private void ShowAllCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _customerRepo.GetCustomer();
            listOfCustomers.Sort(delegate (Customer x, Customer y)
            {
                if (x.FirstName == null && y.FirstName == null) return 0;
                else if (x.FirstName == null) return -1;
                else if (y.FirstName == null) return 1;
                else return x.FirstName.CompareTo(y.FirstName);
            });
            var table = new TablePrinter("FirstName", "LastName", "CustomerType", "Email");
            
            foreach (Customer customer in listOfCustomers)
            {
                table.AddRow(customer.FirstName, customer.LastName, customer.CustomerTypecast, customer.CustomerMessage);
            }
            table.Print();
        }
        private void UpdateCustomer()
        {
            ShowAllCustomers();
            Console.WriteLine("\n\nWhich customer would you like to update?\n" +
                "Enter their first name");
            string oldName = Console.ReadLine();
            Console.Clear();
            Customer newCustomer = new Customer();
            Console.WriteLine("Enter customer's first name");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter customer's last name");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Please select a customer type by number\n" +
                "1: Potential\n" +
                "2: Current\n" +
                "3: Past");
            string customerTypes = Console.ReadLine();
            switch (customerTypes)
            {
                case "1":
                    newCustomer.CustomerTypecast = CustomerType.Potential;
                    break;
                case "2":
                    newCustomer.CustomerTypecast = CustomerType.Current;
                    break;
                case "3":
                    newCustomer.CustomerTypecast = CustomerType.Past;
                    break;
                default:
                    Console.WriteLine("Please enter a valid value");
                    break;
            }
            //verify update
            bool wasUpdated = _customerRepo.UpdateExistingCustomer(oldName, newCustomer);
            if(wasUpdated)
            {
                Console.WriteLine("Customer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update customer.");
            }
        }
        private void DeleteCustomer()
        {
            ShowAllCustomers();
            Console.WriteLine("Which customer would you like to remove?\n" +
                "Enter their first name");
            string input = Console.ReadLine();
            bool wasDeleted = _customerRepo.DeleteExistingCustomer(input);
            if (wasDeleted)
            {
                Console.WriteLine("Customer successfully deleted.");
            }
            else
            {
                Console.WriteLine("Customer could not be deleted.");
            }
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
    //started in its own separate class
    //was added here because I couldn't link it to the ProgramUI in order to create a table
    public class TablePrinter
    {
        private readonly string[] titles;
        private readonly List<int> lengths;
        private readonly List<string[]> rows = new List<string[]>();
        public TablePrinter(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(t => t.Length).ToList();
        }
        public void AddRow(params object[] row)
        {
            if (row.Length != titles.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
            }
            rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < titles.Length; i++)
            {
                if (rows.Last()[i].Length > lengths[i])
                {
                    lengths[i] = rows.Last()[i].Length;
                }
            }
        }
        public void Print()
        {
            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            System.Console.WriteLine(line + "|");
            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';  // numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                System.Console.WriteLine(line + "|");
            }
            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
        }
    }
}
