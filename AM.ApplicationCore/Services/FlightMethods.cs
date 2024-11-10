using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

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

            //methode anonyme
            dates = Flights.Where(f => f.Destination == destination)
                            .Select(f => f.FlightDate);

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

        //////////// LINQ

        //Afficher les dates et les destinations des vols d’un avion passé en paramètre
        public void ShowFlightDetails(Plane plane)
        {
            //type peut contenir n'importe quoi : type anonyme
            var flights = from f in Flights
                          where f.Plane == plane
                          select new {f.FlightDate, f.Destination };

            //methode anonyme
            var req2 = Flights.Where(f=> f.Plane == plane)
                                .Select(f=> new { f.FlightDate, f.Destination });

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

            //methode anonyme
            var req2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req;
        }

        //moyenne de durée 
        //Retourner la moyenne de durée estimées des vols d’une destination donnée
        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where (f.Destination == destination)
                      select f.EstimatedDuration;
            return req.Average();
            
            
            //methode anonyme
            var req2 = Flights.Where(f => f.Destination == destination)
                                .Average(f=>f.EstimatedDuration);
        }

        //comparer 2 dates
        //Retourner le nombre de vols programmés pour une semaine à partir d’une date donnée
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate)<0
                      && (f.FlightDate-startDate).TotalDays<8
                      select f;

            //methode anonyme
            var req2 = Flights.Where(f=> DateTime.Compare(startDate, f.FlightDate) < 0
                      && (f.FlightDate - startDate).TotalDays < 8);

            return req.Count();
        }

        //chercher 3 passagers les plus agés de type traveller
        //Retourner les 3 passagers, de type traveller, les plus âgés d’un vol
        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from t in flight.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t;

            //methode anonyme
            var req2 = flight.Passengers.OfType<Traveller>().OrderBy(t=> t.BirthDate);

            return req.Take(3); // skip pour ignorer les 3 premiers
        }

        //Retourner les vols groupés par destination et les afficher
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            //methode anonyme
            var req2 = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination:" + g.Key);
                foreach (Flight f in g)
                    Console.WriteLine(f);
            }
            return req;             
        }

        //////////////////////// LAMBDA

        //création de 2 délégués

        //1. pointe vers une méthode qui prend un objet Plane en paramètre et ne
        //retourne rien
        public Action<Plane> FlightDetailsDel;

        //2. pointe vers une méthode qui prend une chaine de caractère en
        //paramètre et qui retourne un réel
        public Func<string, double> DurationAverageDel;

        //constructeur non parametré
        //affecter respectivement les deux méthodes ShowFlightDetails et DurationAverage
        //aux deux délégués crées précédemment et tester le résultat.
        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;

            //Affecter aux délégués le même traitement des méthodes ShowFlightDetails et
            //DurationAverage, mais à travers des méthodes anonymes
            DurationAverageDel = dest => {
                                            var req = from f in Flights
                                                      where (f.Destination == dest)
                                                      select f.EstimatedDuration;
                                            return req.Average();
                                        };

            FlightDetailsDel = pl => {
                var flights = from f in Flights
                              where f.Plane == pl
                              select new { f.FlightDate, f.Destination };

                foreach (var f in flights)
                    Console.WriteLine(f); ;
            };
        }

        //Reformuler toutes les méthodes de la section II en se basant sur les méthodes de requêtes
        //prédéfinies de la bibliothèque System.LINQ.
    }
}
