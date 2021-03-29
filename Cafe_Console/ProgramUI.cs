﻿using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
        private readonly CafeRepository _cafeRepository = new CafeRepository();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the option selection number:\n" +
                    "1. Add a meal to menu\n" +
                    "2. View full menu\n" +
                    "3. View meal by number\n" +
                    "4. Delete meal from menu\n" +
                    "5. Exit" );
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        //Add meal to menu
                        CreateNewMeal();
                        break;
                    case "2":
                        //View full menu
                        ViewAllMeals();
                        break;
                    case "3":
                        //view meal by number
                        ViewMealByItsNumber();
                        break;
                    case "4":
                        //delete meal from menu

                        break;
                    case "5":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;

                }
            }
        }
        private void CreateNewMeal()
        {
            Console.Clear();
            Menu menu = new Menu();
            Console.WriteLine("Welcome to the Cafe Menu Page\n" +
                "Please enter Meal Number:");
            menu.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a name for the meal:");
            menu.MealName = Console.ReadLine();
            Console.WriteLine("Please enter a description:");
            menu.Description = Console.ReadLine();
            Console.WriteLine("Please enter the ingredients:");
            menu.Ingredients = Console.ReadLine();
            Console.WriteLine("Please enter the meal price");
            menu.Price = decimal.Parse(Console.ReadLine());

            _cafeRepository.AddMealToDirectory(menu);
        }
        private void ViewAllMeals()
        {
            Console.Clear();
            List<Menu> listOfMeals = _cafeRepository.ViewFullMenu();
            foreach(Menu meal in listOfMeals)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Ingredients: {meal.Ingredients}\n" +
                    $"Price: {meal.Price}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ViewMealByItsNumber()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number");
            int number = int.Parse(Console.ReadLine());
            Menu meal = _cafeRepository.GetMealByNumber(number);
            if(meal != null)
            {
                DisplayMeal(meal);
            }
            else
            {
                Console.WriteLine($"Invalid meal number. Could not find results {number}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        //helper for display by number
        private void DisplayMeal(Menu meal)
        {
            Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Ingredients: {meal.Ingredients}\n" +
                    $"Price: {meal.Price}\n");
        }
        private void RemoveMealFromMenuByNumber()
        {
            Console.Clear();
            Console.WriteLine("Which meal would you like to remove");
            List<Menu> mealList = _cafeRepository.ViewFullMenu();
            int count = 0;
            foreach (Menu meal in mealList)
            {
                count++;
                Console.WriteLine($"{count} {meal.MealNumber}");
            }
            int targetMealNumber = int.Parse(Console.ReadLine());
            int targetIndex = targetMealNumber - 1;
            if (targetIndex >= 0 && targetIndex < mealList.Count)
            {
                Menu desiredMenuItem = mealList[targetIndex];
                if (_cafeRepository.DeleteExistingMeal(desiredMenuItem))
                {
                    Console.WriteLine($"{desiredMenuItem.MealName} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("Attempt to remove meal selected failed.");
                }
            }
            else
            {
                Console.WriteLine("No meal has that number.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedMealList()
        {
            //new menu items

            //_caferepo add to dir 
        }
    }
}
