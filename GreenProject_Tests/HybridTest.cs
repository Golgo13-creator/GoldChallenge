using GreenProject_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GreenProject_Tests
{
    [TestClass]
    public class HybridTest
    {
        [TestMethod]
        //create
        public void AddHybridToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            Hybrid hybrid = new Hybrid();
            Hybrid_Repo repo = new Hybrid_Repo();
            //Act
            bool addResult = repo.AddHybridToList(hybrid);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //read
        public void GetHybridList_ShouldReturnCorrectCollection()
        {
            //arrange
            Hybrid hybrid = new Hybrid();
            Hybrid_Repo repo = new Hybrid_Repo();
            repo.AddHybridToList(hybrid);
            //act
            List<Hybrid> hybridList = repo.GetHybridList();
            bool dirHasHybrids = hybridList.Contains(hybrid);
            //assert
            Assert.IsTrue(dirHasHybrids);
        }
        //supporting fields
        private Hybrid _hybrid;
        private Hybrid_Repo _repo;
        [TestMethod]
        //update
        public void UpdateExistingHybrids_ShouldReturnTrue()
        {
            //arrange
            Hybrid newHybrid = new Hybrid("Honda", "Insight", "48 miles per gallon");
            //act
            bool updateHybrid = _repo.UpdateExistingHybrids("Insight", newHybrid);
            //assert
            Assert.IsTrue(updateHybrid);
        }
        [TestMethod]
        //delete
        public void RemoveHybridFromList_ShouldReturnTrue()
        {
            //arrange
            Hybrid hybrid = _repo.GetHybridByModel("Insight");
            //act
            bool removeHybrid = _repo.RemoveHybridFromList("Insight");
            //assert
            Assert.IsTrue(removeHybrid);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Hybrid_Repo();
            _hybrid = new Hybrid("Honda", "Insight", "48 miles per gallon");
            _repo.AddHybridToList(_hybrid);
        }
        [TestMethod]
        //helper
        public void GetHybridByMake_ShouldReturnCorrectMake()
        {
            //arrange ->done above
            //act
            Hybrid searchResult = _repo.GetHybridByModel("Insight");
            //assert
            Assert.AreEqual(_hybrid, searchResult);
        }
        
    }
}
