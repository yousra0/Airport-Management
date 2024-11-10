using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        //méthode qui retourne liste des dates
        IEnumerable<DateTime> GetFlightDates(string destination);

        //méthode qui affiche les vols en fonction de type de filtre et sa valeur 
        void GetFlights(string filterType, string filterValue);

        //Afficher les dates et les destinations des vols d’un avion passé en paramètre
        void ShowFlightDetails(Plane plane);

        //Retourner les Vols ordonnés par EstimatedDuration du plus long au plus court
        IEnumerable<Flight> OrderedDurationFlights();

        //Retourner la moyenne de durée estimées des vols d’une destination donnée
        double DurationAverage(string destination);

        //Retourner le nombre de vols programmés pour une semaine à partir d’une date donnée
        int ProgrammedFlightNumber(DateTime startDate);

        //Retourner les 3 passagers, de type traveller, les plus âgés d’un vol
        IEnumerable<Traveller> SeniorTravellers(Flight flight);

        //Retourner les vols groupés par destination et les afficher
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    }
}
