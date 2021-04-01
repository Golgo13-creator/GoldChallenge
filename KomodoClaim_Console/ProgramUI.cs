using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim_Console
{
    class ProgramUI
    {
        private Queue<Claim> _nextClaim = new Queue<Claim>();
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaimQueue();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                    "Choose a Menu Item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of the next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        //see all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //take care of the next claim
                        TakeNextClaim();
                        break;
                    case "3":
                        //enter a new claim
                        NewClaim();
                        break;
                    case "4":
                        //exit menu
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
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.ViewAllClaims();
            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfIncident}\n" +

                    //is valid output
                    $"");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void TakeNextClaim()
        {
            Console.Clear();
            
            Claim claim = new Claim();
           
        //peek
        
            Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                $"Claim ID: {claim.ClaimID}\n" +
                $"Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"Date Of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"IsVald: {claim.IsValid}\n\n");

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            //dequeue 
            //switch case 
            //case "y":
            _nextClaim.Dequeue();
            //break;
            //case "n":
            //RunMenu()
            //break;
            //default:
            //Console.WriteLine("Please enter y or n.");
            //break;
            //Console.ReadKey();
            
        }
        private void NewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Welcome to the Create New Claim Menu\n" +
                "Please enter Claim ID:");
            claim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the type of claim:");
           
            claim.ClaimType =; //refer to streamingcontent
           
            Console.WriteLine("Please enter a description of the incident:");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Please enter claim amount:");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the incident:");
            
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter the date of the claim:");
            
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
           
            //compare dates  
            //may have to be its own helper method
            if (claim.DateOfClaim - claim.DateOfIncident <= 30)
            {
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is no longer valid.");
            }
        }
        private void SeedClaimQueue()
        {
            Claim claimA = new Claim(1, TypeOfClaim.Car, "Car accident on 465", 400.00m, "4/25/18", "4/27/18", true);
            Claim claimB = new Claim(2, TypeOfClaim.Home, "House fire in kitchen", 4000.00m, "4/11/18", "4/12/18", true);
            Claim claimC = new Claim(3, TypeOfClaim.Theft, "Stolen Pancakes", 4.00m, "4/27/18", "6/27/18", false);

            _claimRepo.AddAClaimToQueue(claimA);
            _claimRepo.AddAClaimToQueue(claimB);
            _claimRepo.AddAClaimToQueue(claimC);
        }
    }
}
