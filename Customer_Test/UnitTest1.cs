using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Customer_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //create
        public void AddCustomerToDir_ShouldGetCorrectBoolean()
        {
            //Arrange
            Customer customer = new Customer();
            CustomerRepo repo = new CustomerRepo();
            //Act
            bool addResult = repo.AddCustomerToDir(customer);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //read
        public void GetCustomers()
        {
            //Arrange
            //Add content
            Customer customer = new Customer();
            //create repo
            CustomerRepo repo = new CustomerRepo();
            //add content to repo(customer)
            repo.AddCustomerToDir(customer);
            //act
            //store list of customers w/n variable
            List<Customer> customers = repo.GetCustomer();
            //looks thourgh list and returns true if customers exist
            bool directoryHasCustomers = customers.Contains(customer);
            //assert
            Assert.IsTrue(directoryHasCustomers);
        }
        [TestMethod]
        public void GetCustomerByFirstName_ShouldReturnCorrectCustomer()
        {
            //Arrange..already done
            //Act
            Customer searchResult = _repo.GetCustomerByFirstName("Kanye");
            //Assert
            Assert.AreEqual(_customer, searchResult);
        }
        private Customer _customer;
        private CustomerRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CustomerRepo();
            _customer = new Customer("Kanye", "West", CustomerType.Current);
            _repo.AddCustomerToDir(_customer);
        }
        [TestMethod]
        //update
        public void UpdateExistingCustomer_ShouldReturnTrue()
        {
            //Arrange
            Customer newCustomer = new Customer("Kanye", "West", CustomerType.Past);
            //Act
            bool updateCustomer = _repo.UpdateExistingCustomer("Kanye", newCustomer);
            //Assert
            Assert.IsTrue(updateCustomer);
        }
        [TestMethod]
        //delete
        public void DeleteExistingCustomer_ShouldReturnTrue()
        {
            //Arrange
            Customer customer = _repo.GetCustomerByFirstName("Kanye");
            //Act
            bool removeCustomer = _repo.DeleteExistingCustomer(customer);
            //Assert
            Assert.IsTrue(removeCustomer);
        }
    }
}
