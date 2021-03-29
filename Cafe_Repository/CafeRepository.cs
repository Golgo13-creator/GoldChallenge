using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class CafeRepository
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();
        //create
        public bool AddMealToDirectory(Menu meal)
        {
            int StartingCount = _menuDirectory.Count;
            _menuDirectory.Add(meal);
            bool wasAdded = (_menuDirectory.Count > StartingCount) ? true : false;
            return wasAdded;
        }
        //read
        public List<Menu> ViewFullMenu()
        {
            return _menuDirectory;
        }
        //delete
        public bool DeleteExistingMeal(Menu existingMeal)
        {
            bool deleteMeal = _menuDirectory.Remove(existingMeal);
            return deleteMeal;
        }
        public Menu GetMealByNumber(int number)
        {
            foreach(Menu meal in _menuDirectory)
            {
                if(meal.MealNumber == number)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
