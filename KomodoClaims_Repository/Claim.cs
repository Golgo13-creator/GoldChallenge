using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public enum TypeOfClaim { Car, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        //fix date properties
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public Claim()
        {
                
        }
        public Claim(int claimID, TypeOfClaim claimType, string description, decimal claimAmount, string dateOfIncident, string dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
}
