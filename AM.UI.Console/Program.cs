// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

//constructeur non paramétré
Plane plane = new Plane();

plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boeing;


//constructeur paramétré
//Plane plane1  =  new Plane(100,DateTime.Now,PlaneType.Airbus);

//initialiseur d'objets
Plane plane2 = new Plane { Capacity = 200, 
                           ManufactureDate= new DateTime(2024,09,01)};

//affichage
Console.WriteLine(plane);

//création / initialisation d'un objet Passenger
Passenger p1 = new Passenger { FirstName = "yousra",
                                LastName = "chaieb",
                                EmailAddress = "yousra.chaieb@esprit.tn"};

//vérification du profil avec CheckProfile
Console.WriteLine("************ Check Profile ************");
Console.WriteLine(p1.CheckProfile("yousra","chaieb","abc"));


//Appel de la méthode PassengerType
Console.WriteLine("************ Passenger Type ************");

//Création des objets Staff et Traveller
Staff s1 = new Staff { FirstName = "staff1" };
Traveller t1 = new Traveller { FirstName = "traveller1" };

p1.PassengerType();
t1.PassengerType();
s1.PassengerType();

//tester la méthode qui retourne les dates de vols
Console.WriteLine("************ Get Flight Dates ************");
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
/*for(int i = 0; i < fm.GetFlightDates("Paris").Count; i++)
    Console.WriteLine(fm.GetFlightDates("Paris")[i]);*/
foreach (DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);


//tester la méthode qui affiche les vols en fonction de type de filtre et sa valeur
Console.WriteLine("************ Get Flights ************");
fm.GetFlights("Destination", "Madrid");
fm.GetFlights("EstimatedDuration", "100");

//Afficher les dates et les destinations des vols d’un avion passé en paramètre
Console.WriteLine("************ Show Flight Details ************");
fm.ShowFlightDetails(TestData.BoingPlane);

//tri desc selon date
//Retourner les Vols ordonnés par EstimatedDuration du plus long au plus court
Console.WriteLine("************ Ordered Duration Flights ************");
foreach (Flight f in fm.OrderedDurationFlights())
    Console.WriteLine(f); ;

//moyenne de durée 
//Retourner la moyenne de durée estimées des vols d’une destination donnée
Console.WriteLine("************ Average Duration ************");
Console.WriteLine(fm.DurationAverage("Paris"));

//appel avec le délégué
Console.WriteLine("************ Average Duration Avec Délégué************");
Console.WriteLine(fm.DurationAverageDel("Paris"));

//comparer 2 dates
//Retourner le nombre de vols programmés pour une semaine à partir d’une date donnée
Console.WriteLine("************ Programmed Flight Number ************");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));

//chercher 3 passagers les plus agés de type traveller
//Retourner les 3 passagers, de type traveller, les plus âgés d’un vol
Console.WriteLine("************ Senior Travellers ************");
foreach (Traveller t in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine($"FirstName: {t.FirstName}, LastName {t.LastName}, Date of Birth: {t.BirthDate.ToShortDateString()}");
}

//Retourner les vols groupés par destination et les afficher
Console.WriteLine("************ Destination grouped Flights ************");
fm.DestinationGroupedFlights();

//Extension
Console.WriteLine("******** Extension ********");
p1.UpperFullName();
Console.WriteLine(p1.FirstName+" "+p1.LastName);

















