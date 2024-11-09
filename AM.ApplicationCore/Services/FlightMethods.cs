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
        //liste vide
        public IEnumerable<Flight> Flights { get; set; } = new List<Flight>();

        //implémentation de la fonction de retour de liste des dates
        //des vols implémenter dans l'interface avec boucle for
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> dates = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination) 
                    dates.Add(Flights[i].FlightDate);
            }*/

            /*foreach (Flight f in  Flights)
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);*/

            //Reformuler la méthode en utilisant LINQ
            dates = from f in Flights
                    where f.Destination == destination
                    select f.FlightDate;

            return dates;
        }

        //implémentation de la méthode qui affiche les vols en fonction
        //de type de filtre et sa valeur 
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                        if (f.Destination == filterValue)
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

        //Afficher les dates et les destinations des vols d’un avion passé en paramètre
        public void ShowFlightDetails(Plane plane)
        {
            //type peut contenir n'importe quoi : type anonyme
            var flights = from f in Flights
                          where f.Plane == plane
                          select new {f.FlightDate, f.Destination };
            
            foreach (var f in flights)
                Console.WriteLine(f); ;
        }

        //tri desc selon date (si asc, on supprime descending)
        //Retourner les Vols ordonnés par EstimatedDuration du plus long au plus court
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            return req;
        }
    }
}
