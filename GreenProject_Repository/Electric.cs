using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    public class Electric : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string FuelEfficiency  { get; set; }
        public Electric()
        {

        }
        public Electric(string make, string model, string fuelEfficiency)
        {
            Make = make;
            Model = model;
            FuelEfficiency = fuelEfficiency;
        }
    }
}
