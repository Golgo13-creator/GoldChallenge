using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    public class Hybrid_Repo
    {
        private List<Hybrid> _listofHybrids = new List<Hybrid>();
        public bool AddHybridToList(Hybrid hybrid)
        {
            int startingCount = _listofHybrids.Count;
            _listofHybrids.Add(hybrid);
            bool wasAdded = (_listofHybrids.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Hybrid> GetHybridList()
        {
            return _listofHybrids;
        }
        public bool UpdateExistingHybrids(string originalMake, Hybrid newHybrid)
        {
            Hybrid oldHybrid = GetHybridByMake(originalMake);

            if(oldHybrid != null)
            {
                oldHybrid.Make = newHybrid.Make;
                oldHybrid.Model = newHybrid.Model;
                oldHybrid.FuelEfficiency = newHybrid.FuelEfficiency;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveHybridFromList(string make)
        {
            Hybrid hybrid = GetHybridByMake(make);
            if(hybrid == null)
            {
                return false;
            }
            int initialCount = _listofHybrids.Count();
            _listofHybrids.Remove(hybrid);
            if(initialCount > _listofHybrids.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public Hybrid GetHybridByMake(string make)
        {
            foreach(Hybrid hybrid in _listofHybrids)
            {
                if(hybrid.Make.ToLower() == make.ToLower())
                { 
                    return hybrid; 
                }
            }
            return null;
        }
    }
}
