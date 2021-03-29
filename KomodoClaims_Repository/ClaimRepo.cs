using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class ClaimRepo
    {
        private Queue<Claim> _claims = new Queue<Claim>();
        //create
        public bool AddAClaimToQueue(Claim claim)
        {
            int StartingCount = _claims.Count;
            _claims.Enqueue(claim);
            bool wasAdded = (_claims.Count > StartingCount) ? true : false;
            return wasAdded;
        }
        //read
        public Queue<Claim> ViewAllClaims()
        {
            return _claims;
        }
        //remove
        public void TakeCareOfNextClaim(Claim existingclaim)
        {
            Claim removeClaim = _claims.Dequeue();
            Console.WriteLine($"{existingclaim} has been removed from the queue."); 
        }
        public Claim GetClaimById(int number)
        {
            foreach (Claim claim in _claims)
            {
                if(claim.ClaimID == number)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
