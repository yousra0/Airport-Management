﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        IEnumerable<DateTime> GetFlightDates(string dest);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        IEnumerable<Flight> OrderedDurationFlights();
    }
}
