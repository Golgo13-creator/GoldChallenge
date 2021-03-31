using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    public class Gas_Repo
    {
        private List<Gas> _listofGas = new List<Gas>();
        public bool AddGasToList(Gas gas)
        {
            int startingCount = _listofGas.Count;
            _listofGas.Add(gas);
            bool wasAdded = (_listofGas.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Gas> GetGasList()
        {
            return _listofGas;
        }
        public bool UpdateExistingGas(string originalMake, Gas newGas)
        {
            Gas oldGas = GetGasByMake(originalMake);

            if (oldGas != null)
            {
                oldGas.Make = newGas.Make;
                oldGas.Model = newGas.Model;
                oldGas.FuelEfficiency = newGas.FuelEfficiency;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveGasFromList(string make)
        {
            Gas gas = GetGasByMake(make);
            if (gas == null)
            {
                return false;
            }
            int initialCount = _listofGas.Count();
            _listofGas.Remove(gas);
            if (initialCount > _listofGas.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public Gas GetGasByMake(string make)
        {
            foreach (Gas gas in _listofGas)
            {
                if (gas.Make.ToLower() == make.ToLower())
                {
                    return gas;
                }
            }
            return null;
        }
    }
}
