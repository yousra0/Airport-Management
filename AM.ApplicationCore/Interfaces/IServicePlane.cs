﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        IEnumerable<Passenger> GetPassenger(Plane plane);
        IEnumerable<Flight> GetFlights(int n);
        Boolean IsAvailablePlane(Flight f,int n);
        void DeletePlanes();
    }
}
