using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Testing the Create method
        public void AddMealToDir_ShouldGetCorrectBoolean()
        {
            //Arrange, Act, Assert
            //Arrange -> Overall Setup
            Menu menu = new Menu();
            CafeRepository repository = new CafeRepository();
            //Act -> Get/Run the code to test
            bool addResult = repository.AddMealToDirectory(menu);
            //Assert -> Get expected outcome of the test
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //testing the read method
        public void GetMeal_ShouldReturnCorrectCollection()
        {
            //arrange
            //creating the menu
            Menu menu = new Menu();
            //creating the repo
            CafeRepository repository = new CafeRepository();
            //adding to the repo(menu)
            repository.AddMealToDirectory(menu);
            //act
            //store list of meals w/n a variable
            List<Menu> menuList = repository.ViewFullMenu();
            //looks through our entire list and returns true if there is content
            bool directoryHasMeals = menuList.Contains(menu);
            //assert
            Assert.IsTrue(directoryHasMeals);
        }
        //delete
        [TestMethod]
        public void DeleteExistingMeal_ShouldReturnTrue()
        {
            //Arrange
            Menu menu = _repo.GetMealByNumber(1);
            //Act
            bool removeResult = _repo.DeleteExistingMeal(menu);
            //Assert
            Assert.IsTrue(removeResult);
        }
        //fields to support Arrange method
        private CafeRepository _repo;
        private Menu _meal;
        //Arrange Method
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepository();
            _meal = new Menu(1, "Hamburger\n", "Fresh never frozen beef on a sesame seed bun with fries\n",
                "Sesame Seed Bun\n " +
                "Beef Patty\n" +
                "Lettuce\n" +
                "Tomato\n" +
                "Onions" +
                "Ketchup\n",
                5.00m);
            _repo.AddMealToDirectory(_meal);
        }
        //retrieve meal by number
        [TestMethod]
        public void GetMealByNumber_ShouldReturnCorrectMeal()
        {
            //Arrange -> arrange method above
            //Act
            Menu searchResult = _repo.GetMealByNumber(1);
            //Assert
            Assert.AreEqual(_meal, searchResult);
        }
    }
}
