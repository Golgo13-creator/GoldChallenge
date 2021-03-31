using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    public class Gas : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string FuelEfficiency { get; set; }
        public Gas()
        {

        }
        public Gas(string make, string model, string fuelEfficiency)
        {
            Make = make;
            Model = model;
            FuelEfficiency = fuelEfficiency;
        }
    }
}
