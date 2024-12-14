﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string AirlineLogo { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        //Objets de navigation
        [ForeignKey("PlaneFk")]
        public virtual Plane Plane { get; set; }
      
        //[ForeignKey("Plane")]
        public int PlaneFk { get; set; }
        //public ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Destination: " + Destination 
                + " FlightDate: " + FlightDate
                + " EstimatedDuration: " + EstimatedDuration;
        }
    }
}
