using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public Plane Plane { get; set; }
        public List<Passenger> Passengers { get; set; }

        // Redéfinition de ToString pour un affichage personnalisé
        public override string ToString()
        {
            return "Destination:" + Destination +
                    "flightDate:" + FlightDate +
                    "EstimatedDuration:" + EstimatedDuration;
        }
    }
}
