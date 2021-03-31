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
    public class GasTest
    {
        [TestMethod]
        //create
        public void AddGasToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            Gas gas = new Gas();
            Gas_Repo repo = new Gas_Repo();
            //Act
            bool addResult = repo.AddGasToList(gas);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //read
        public void GetGasList_ShouldReturnCorrectCollection()
        {
            //arrange
            Gas gas = new Gas();
            Gas_Repo repo = new Gas_Repo();
            repo.AddGasToList(gas);
            //act
            List<Gas> gasList = repo.GetGasList();
            bool dirHasGas = gasList.Contains(gas);
            //assert
            Assert.IsTrue(dirHasGas);
        }
        //supporting fields
        private Gas _gas;
        private Gas_Repo _repo;
        [TestMethod]
        //update
        public void UpdateExistingGas_ShouldReturnTrue()
        {
            //arrange
            Gas newGas = new Gas("GMC", "Sierra", "17 miles per gallon");
            //act
            bool updateGas = _repo.UpdateExistingGas("GMC", newGas);
            //assert
            Assert.IsTrue(updateGas);
        }
        [TestMethod]
        //delete
        public void RemoveHybridFromList_ShouldReturnTrue()
        {
            //arrange
            Gas gas = _repo.GetGasByMake("GMC");
            //act
            bool removeGas = _repo.RemoveGasFromList("GMC");
            //assert
            Assert.IsTrue(removeGas);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Gas_Repo();
            _gas = new Gas("GMC", "Sierra", "17 miles per gallon");
            _repo.AddGasToList(_gas);
        }
        [TestMethod]
        //helper
        public void GetGasByMake_ShouldReturnCorrectMake()
        {
            //arrange ->done above
            //act
            Gas searchResult = _repo.GetGasByMake("GMC");
            //assert
            Assert.AreEqual(_gas, searchResult);
        }

    }
}

