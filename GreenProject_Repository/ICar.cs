using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject_Repository
{
    interface ICar
    {
        string Make { get; set; }
        string Model { get; set; }
        string FuelEfficiency { get; set; }
    }
}
