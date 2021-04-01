using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert}
    public class Outings
    {
        public EventType TypeOfEvent { get; set; }
        public int NumberOfPeopleAttended { get; set; }
        public string Date { get; set; }
        public int TotalCostPerPerson { get; set; }
        public int TotalCostPerEvent { get; set; }
        public Outings()
        {

        }
        public Outings(EventType typeOfEvent, int numberOfPeopleAttended, string date, int totalCostPerPerson, int totalCostPerEvent)
        {
            TypeOfEvent = typeOfEvent;
            NumberOfPeopleAttended = numberOfPeopleAttended;
            Date = date;
            TotalCostPerPerson = totalCostPerPerson;
            TotalCostPerEvent = totalCostPerEvent;
        }
    }
}
