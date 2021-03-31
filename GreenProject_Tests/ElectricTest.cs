using GreenProject_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Tests
{
    [TestClass]
    public class ElectricTest
    {
        [TestMethod]
        //create
        public void AddElectricToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            Electric electric = new Electric();
            Electric_Repo repo = new Electric_Repo();
            //Act
            bool addResult = repo.AddElectricToList(electric);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //read
        public void GetElectricList_ShouldReturnCorrectCollection()
        {
            //arrange
            Electric electric = new Electric();
            Electric_Repo repo = new Electric_Repo();
            repo.AddElectricToList(electric);
            //act
            List<Electric> electricList = repo.GetElectricList();
            bool dirHasElectric = electricList.Contains(electric);
            //assert
            Assert.IsTrue(dirHasElectric);
        }
        //supporting fields
        private Electric _electric;
        private Electric_Repo _repo;
        [TestMethod]
        //update
        public void UpdateExistingElectric_ShouldReturnTrue()
        {
            //arrange
            Electric newElectric = new Electric("Tesla","Model 3", "30kWh/100mi");
            //act
            bool updateElectric = _repo.UpdateExistingElectric("Tesla", newElectric);
            //assert
            Assert.IsTrue(updateElectric);
        }
        [TestMethod]
        //delete
        public void RemoveHybridFromList_ShouldReturnTrue()
        {
            //arrange
            Electric electric = _repo.GetElectricByMake("Tesla");
            //act
            bool removeHybrid = _repo.RemoveElectricFromList("Tesla");
            //assert
            Assert.IsTrue(removeHybrid);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Electric_Repo();
            _electric = new Electric("Tesla", "Model 3", "30kWh/100mi");
            _repo.AddElectricToList(_electric);
        }
        [TestMethod]
        //helper
        public void GetElectricByMake_ShouldReturnCorrectMake()
        {
            //arrange ->done above
            //act
            Electric searchResult = _repo.GetElectricByMake("Tesla");
            //assert
            Assert.AreEqual(_electric, searchResult);
        }
    }
}
