using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //testing create method
        public void AddClaimToQueue_ShouldGetCorrectBoolean()
        {
            //Arrange
            Claim claim = new Claim();
            ClaimRepo repo = new ClaimRepo();
            //Act
            bool addResult = repo.AddAClaimToQueue(claim);
            //Assert
            Assert.IsTrue(addResult);
        }
        //Read
        [TestMethod]
        public void ViewAllClaims_ShouldReturnAllClaimsInQueue()
        {
            //Arrange
            Claim claim = new Claim();
            //creating the repo
            ClaimRepo repo = new ClaimRepo();
            //adding to the repo(claim)
            repo.AddAClaimToQueue(claim);
            //act
            //store queue of claims within a variable
            Queue<Claim> claimQueue = repo.ViewAllClaims();
            //looks through our entire queue and returns true if there is content
            bool queueHasClaims = claimQueue.Contains(claim);
            //assert
            Assert.IsTrue(queueHasClaims);
        }
        //Delete
        [TestMethod]
        public void TakeCareOfNextClaim_ShouldReturnTrue()
        {
            //Arrange
            Claim claim = _repo.GetClaimById(1);
            //Act
            bool removeResult = _repo.TakeCareOfNextClaim(claim);
            //Assert
            Assert.IsTrue(claim);
        }
        private ClaimRepo _repo;
        private Claim _claim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new Claim(1, TypeOfClaim.Car,
                "Car accident on 465", 400.00m,
                 "04/25/2018", "04/27/2018", true);
            _repo.AddAClaimToQueue(_claim);
        }
        [TestMethod]
        public void ViewClaimById()
        {
            //Arrange ->above
            //Act
            Claim searchResult = _repo.GetClaimById(1);
            //Assert
            Assert.AreEqual(_claim, searchResult);
        }

    }
}
