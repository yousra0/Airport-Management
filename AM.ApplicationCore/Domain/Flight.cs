﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        //Objets de navigation
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public override string ToString()
        {
            return "Destination: " + Destination 
                + " FlightDate: " + FlightDate
                + " EstimatedDuration: " + EstimatedDuration;
        }
    }
}
