using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    public class Electric_Repo
    {
        private List<Electric> _listofElectric = new List<Electric>();
        public bool AddElectricToList(Electric electric)
        {
            int startingCount = _listofElectric.Count;
            _listofElectric.Add(electric);
            bool wasAdded = (_listofElectric.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Electric> GetElectricList()
        {
            return _listofElectric;
        }
        public bool UpdateExistingElectric(string originalMake, Electric newElectric)
        {
            Electric oldElectric = GetElectricByMake(originalMake);

            if (oldElectric != null)
            {
                oldElectric.Make = newElectric.Make;
                oldElectric.Model = newElectric.Model;
                oldElectric.FuelEfficiency = newElectric.FuelEfficiency;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveElectricFromList(string make)
        {
            Electric electric = GetElectricByMake(make);
            if (electric == null)
            {
                return false;
            }
            int initialCount = _listofElectric.Count();
            _listofElectric.Remove(electric);
            if (initialCount > _listofElectric.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public Electric GetElectricByMake(string make)
        {
            foreach (Electric electric in _listofElectric)
            {
                if (electric.Make.ToLower() == make.ToLower())
                {
                    return electric;
                }
            }
            return null;
        }
    }
}
