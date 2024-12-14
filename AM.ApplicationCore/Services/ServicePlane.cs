using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            //var oldplanes = GetMany(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);
            //foreach (var plane in oldplanes) 
            //{
            //    Delete(plane);
            //}

            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);

        }

        public IEnumerable<Flight> GetFlights(int n)
        {
         return   GetMany().OrderByDescending(p => p.PlaneId)
                     .Take(n).SelectMany(p => p.Flights)
                     .OrderBy(f => f.FlightDate);

        }

        public IEnumerable<Passenger> GetPassenger(Plane plane)
        {
            return plane.Flights.SelectMany(f=>f.Tickets)
                                .Select(f=>f.Passenger);
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            int available = f.Plane.Capacity-f.Tickets.Count;
            return available > n;
        }
    }
}
