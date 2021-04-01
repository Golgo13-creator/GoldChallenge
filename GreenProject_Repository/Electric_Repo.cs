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
        public bool UpdateExistingElectric(string originalModel, Electric newElectric)
        {
            Electric oldElectric = GetElectricByModel(originalModel);

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
        public bool RemoveElectricFromList(string model)
        {
            Electric electric = GetElectricByModel(model);
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
        public Electric GetElectricByModel(string model)
        {
            foreach (Electric electric in _listofElectric)
            {
                if (electric.Model.ToLower() == model.ToLower())
                {
                    return electric;
                }
            }
            return null;
        }
    }
}
