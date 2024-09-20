using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing, Airbus
    }
    public class Plane
    {
        /*private int capacity;
        public int GetCapacity()    { return capacity; }
        public void SetCapacity()   {  this.capacity=capacity; }*/

        //Property : private attribut + public getter and setter
        public int PlaneID { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Capacity" + Capacity
                + "" + "ManufactureDate" + ManufactureDate;
        }
    }
}
