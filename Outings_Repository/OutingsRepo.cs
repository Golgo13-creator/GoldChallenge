using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    class OutingsRepo
    {
        protected readonly List<Outings> _listOfOutings = new List<Outings>();
        public bool AddOutingToList(Outings outing)
        {
            int StartingCount = _listOfOutings.Count;
            _listOfOutings.Add(outing);
            bool wasAdded = (_listOfOutings.Count > StartingCount) ? true : false;
            return wasAdded;
        }
        public List<Outings> GetAllOutings()
        {
            return _listOfOutings;
        }
        public void CombinedCostOfOuting()
        {

        }
        public int EventCost()
        {
            Outings outing = new Outings();
            int product = outing.TotalCostPerPerson * outing.NumberOfPeopleAttended;
            return product;
        }
        
    }
}
