using GreenProject_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Console
{
    public class ProgramUI
    {
        private Hybrid_Repo hybrid_Repo = new Hybrid_Repo();
        private Electric_Repo electric_Repo = new Electric_Repo();
        private Gas_Repo gas_Repo = new Gas_Repo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.WriteLine("Select Menu Option:\n" +
                    "Hybrid Section\n" +
                    "1. Create new Hybrid\n" +
                    "2. Get list of Hybrids\n" +
                    "3. Update Existing Hybrids\n" +
                    "4. Remove Hybrid from list\n" +
                    "5. View Hybrid Details\n" +
                    "----------------------------\n" +
                    "Electric Section\n" +
                    "6. Create new Electric Car\n" +
                    "7. Get list of Electric Cars\n" +
                    "8. Update Existing Electric Cars\n" +
                    "9. Remove Electric Car from list\n" +
                    "10. View Electric Car Details\n" +
                    "----------------------------\n" +
                    "Gas Section\n" +
                    "11.Create new Electric Car\n" +
                    "12. Get list of Electric Cars\n" +
                    "13. Update Existing Electric Cars\n" +
                    "14. Remove Electric Car from list\n" +
                    "15. View Electric Car Details\n" +
                    "----------------------------\n" +
                    "16. Exit");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        CreateNewHybrid();
                        break;
                    case "2":
                        GetListOfHybrids();
                        break;
                    case "3":
                        UpdateHybrid();
                        break;
                    case "4":
                        RemoveHybrid();
                        break;
                    case "5":
                        ViewHybridDetails();
                        break;
                    case "6":
                        CreateNewElectric();
                        break;
                    case "7":
                        GetListOfElectric();
                        break;
                    case "8":
                        UpdateElectric();
                        break;
                    case "9":
                        RemoveElectric();
                        break;
                    case "10":
                        ViewElectricDetails();
                        break;
                    case "11":
                        CreateNewGas();
                        break;
                    case "12":
                        GetListOfGas();
                        break;
                    case "13":
                        UpdateGas();
                        break;
                    case "14":
                        RemoveGas();
                        break;
                    case "15":
                        ViewGasDetails();
                        break;
                    case "16":
                        Console.WriteLine("Until next time");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewHybrid()
        {
            Console.Clear();
            Hybrid newHybrid = new Hybrid();
            Console.WriteLine("Enter the Make");
            newHybrid.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newHybrid.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newHybrid.FuelEfficiency = Console.ReadLine();
            hybrid_Repo.AddHybridToList(newHybrid);
        }
        private void GetListOfHybrids()
        {
            Console.Clear();
            List<Hybrid> listOfHybrid = hybrid_Repo.GetHybridList();
            foreach (Hybrid hybrid in listOfHybrid)
            {
                Console.WriteLine($"\nMake: {hybrid.Make}\n" +
                    $"Model: {hybrid.Model}\n" +
                    $"Fuel Efficiency: {hybrid.FuelEfficiency}");
            }
        }
        private void UpdateHybrid()
        {
            GetListOfHybrids();
            Console.WriteLine("\nEnter the Model of the hybrid to be updated");
            Hybrid hybrid = new Hybrid();
            string oldModel = Console.ReadLine();
            Console.Clear();
            Hybrid newHybrid = new Hybrid();
            Console.WriteLine("Enter the Make");
            newHybrid.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newHybrid.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newHybrid.FuelEfficiency = Console.ReadLine();
            bool wasUpdated = hybrid_Repo.UpdateExistingHybrids(oldModel, newHybrid);
            if(wasUpdated)
            {
                Console.WriteLine("Hybrid updated!");
            }
            else
            {
                Console.WriteLine("Could not update Hybrid.");
            }

        }
        private void RemoveHybrid()
        {
            GetListOfHybrids();
            Console.WriteLine("\nEnter the Model of the hybrid to be removed");
            string input = Console.ReadLine();
            bool wasDeleted = hybrid_Repo.RemoveHybridFromList(input);
            if(wasDeleted)
            {
                Console.WriteLine("Hybrid was deleted.");
            }
            else
            {
                Console.WriteLine("Hybrid could not be deleted.");
            }
        }
        private void ViewHybridDetails()
        {
            Console.Clear();
            Console.WriteLine("\nEnter Make of Hybrid");
            string model = Console.ReadLine();
            Hybrid hybrid = hybrid_Repo.GetHybridByModel(model);
            if(model != null)
            {
                Console.WriteLine($"Make: {hybrid.Make}\n" +
                                  $"Model: {hybrid.Model}\n" +
                                  $"Fuel Efficiency: {hybrid.FuelEfficiency}");
            }
        }
        private void CreateNewElectric()
        {
            Console.Clear();
            Electric newElectric = new Electric();
            Console.WriteLine("Enter the Make");
            newElectric.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newElectric.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newElectric.FuelEfficiency = Console.ReadLine();
            electric_Repo.AddElectricToList(newElectric);
        }
        private void GetListOfElectric()
        {
            Console.Clear();
            List<Electric> listOfElectric = electric_Repo.GetElectricList();
            foreach(Electric electric in listOfElectric)
            {
                Console.WriteLine($"\nMake: {electric.Make}\n" +
                    $"Model: {electric.Model}\n" +
                    $"Fuel Efficiency: {electric.FuelEfficiency}");
            }
        }
        private void UpdateElectric()
        {
            GetListOfElectric();
            Console.WriteLine("\nEnter the Model of the electric car to be updated");
            string oldModel = Console.ReadLine();
            Console.Clear();
            Electric newElectric = new Electric();
            Console.WriteLine("Enter the Make");
            newElectric.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newElectric.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newElectric.FuelEfficiency = Console.ReadLine();
            bool wasUpdated = electric_Repo.UpdateExistingElectric(oldModel, newElectric);
            if (wasUpdated)
            {
                Console.WriteLine("Electric Car updated!");
            }
            else
            {
                Console.WriteLine("Could not update Electric Car.");
            }
        }
        private void RemoveElectric()
        {
            GetListOfElectric();
            Console.WriteLine("\nEnter the Model of the electric car to be removed");
            string input = Console.ReadLine();
            bool wasDeleted = electric_Repo.RemoveElectricFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Electric car was deleted.");
            }
            else
            {
                Console.WriteLine("Electric car could not be deleted.");
            }
        }
        private void ViewElectricDetails()
        {
            Console.Clear();
            Console.WriteLine("\nEnter Model of Electric Car");
            string model = Console.ReadLine();
            Electric electric = electric_Repo.GetElectricByModel(model);
            if (model != null)
            {
                Console.WriteLine($"Make: {electric.Make}\n" +
                                  $"Model: {electric.Model}\n" +
                                  $"Fuel Efficiency: {electric.FuelEfficiency}");
            }
        }
        private void CreateNewGas()
        {
            Console.Clear();
            Gas newGas = new Gas();
            Console.WriteLine("Enter the Make");
            newGas.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newGas.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newGas.FuelEfficiency = Console.ReadLine();
            gas_Repo.AddGasToList(newGas);
        }
        private void GetListOfGas()
        {
            Console.Clear();
            List<Gas> listOfGas = gas_Repo.GetGasList();
            foreach (Gas gas in listOfGas)
            {
                Console.WriteLine($"\nMake: {gas.Make}\n" +
                    $"Model: {gas.Model}\n" +
                    $"Fuel Efficiency: {gas.FuelEfficiency}");
            }
        }
        private void UpdateGas()
        {
            GetListOfGas();
            Console.WriteLine("\nEnter the Model of the gas car to be updated");
            string oldModel = Console.ReadLine();
            Console.Clear();
            Gas newGas = new Gas();
            Console.WriteLine("Enter the Make");
            newGas.Make = Console.ReadLine();
            Console.WriteLine("Enter the Model");
            newGas.Model = Console.ReadLine();
            Console.WriteLine("Enter fuel efficiency information");
            newGas.FuelEfficiency = Console.ReadLine();
            bool wasUpdated = gas_Repo.UpdateExistingGas(oldModel, newGas);
            if (wasUpdated)
            {
                Console.WriteLine("Gas Car updated!");
            }
            else
            {
                Console.WriteLine("Could not update Gas Car.");
            }
        }
        private void RemoveGas()
        {
            GetListOfGas();
            Console.WriteLine("\nEnter the Model of the gas car to be removed");
            string input = Console.ReadLine();
            bool wasDeleted = gas_Repo.RemoveGasFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Gas car was deleted.");
            }
            else
            {
                Console.WriteLine("Gas car could not be deleted.");
            }
        }
        private void ViewGasDetails()
        {
            Console.Clear();
            Console.WriteLine("\nEnter Model of Gas Car");
            string model = Console.ReadLine();
            Gas gas = gas_Repo.GetGasByModel(model);
            if (model != null)
            {
                Console.WriteLine($"Make: {gas.Make}\n" +
                                  $"Model: {gas.Model}\n" +
                                  $"Fuel Efficiency: {gas.FuelEfficiency}");
            }
        }
        private void SeedContentList()
        {
            Hybrid hybridA = new Hybrid("Honda", "Insight", "48-52 miles per gallon");
            Hybrid hybridB = new Hybrid("Ford", "Escape", "40-41 miles per gallon");
            Hybrid hybridC = new Hybrid("Toyota", "Highlander Hybrid", "35-36 miles per gallon");

            hybrid_Repo.AddHybridToList(hybridA);
            hybrid_Repo.AddHybridToList(hybridB);
            hybrid_Repo.AddHybridToList(hybridC);

            Electric electricA = new Electric("Tesla", "Model 3", "30kWh/100 miles");
            Electric electricB = new Electric("Kia", "Niro", "30kWh/100 miles");
            Electric electricC = new Electric("Volkswagen", "ID.4", "35kWh/100 miles");

            electric_Repo.AddElectricToList(electricA);
            electric_Repo.AddElectricToList(electricB);
            electric_Repo.AddElectricToList(electricC);
            
            Gas gasA = new Gas("Ram", "1500", "12-23 miles per gallon");
            Gas gasB = new Gas("GMC", "Sierra", "12-23 miles per gallon");
            Gas gasC = new Gas("Honda", "Ridgeline", "17-24 miles per gallon");

            gas_Repo.AddGasToList(gasA);
            gas_Repo.AddGasToList(gasB);
            gas_Repo.AddGasToList(gasC);
        }
        
    }
}
