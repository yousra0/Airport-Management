using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }=new List<Flight>(){ };

        public IEnumerable<DateTime> GetFlightDates(string dest)
        {
            IEnumerable<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if(Flights[i].Destination == dest)
            //        result.Add(Flights[i].FlightDate);

            //}
            //foreach (Flight f in Flights)
            //    if (f.Destination == dest)
            //        result.Add(f.FlightDate);
            result = from f in Flights
                     where f.Destination == dest
                     select f.FlightDate;
            return result;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    foreach(Flight f in Flights)
                        if(f.Destination == filterValue)
                            Console.WriteLine(f);
                break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure == filterValue)
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration == Int32.Parse(filterValue))
                            Console.WriteLine(f);
                    break;
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
           var req = from f in Flights
                     orderby f.EstimatedDuration descending
                     select f;
            return req;
        }

        public void ShowFlightDetails(Plane plane)
        {
           
           var req = from f in Flights
                               where f.Plane == plane
                               select new { f.Destination, f.FlightDate };
            foreach(var f in req)
                Console.WriteLine(f);
        }
    }
}
