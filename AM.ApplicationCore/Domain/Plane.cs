using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Airbus,
        Boeing
    }
    public class Plane
    {
        public int PlaneID { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int MyProperty { get; set; }
        public PlaneType PlaneType { get; set; }
        public List<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Capacity:" + Capacity +
                    "PlaneType" + PlaneType;
        }
        /*public Plane()
        {
        }
        public Plane(int planeID, int capacity, DateTime manufactureDate, int myProperty, PlaneType planeType, List<Flight> flights)
        {
            PlaneID = planeID;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            MyProperty = myProperty;
            PlaneType = planeType;
            Flights = flights;
        }
        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }*/
    }
}
