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
Console.WriteLine("**** Check Profile ****");
Console.WriteLine(p1.CheckProfile("yousra","chaieb","abc"));


//Appel de la méthode PassengerType
Console.WriteLine("**** Passenger Type ****");

//Création des objets Staff et Traveller
Staff s1 = new Staff { FirstName = "staff1" };
Traveller t1 = new Traveller { FirstName = "traveller1" };

p1.PassengerType();
t1.PassengerType();
s1.PassengerType();

//tester la méthode qui retourne les dates de vols
Console.WriteLine("**** Get Flight Dates ****");
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
/*for(int i = 0; i < fm.GetFlightDates("Paris").Count; i++)
    Console.WriteLine(fm.GetFlightDates("Paris")[i]);*/
foreach (DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);


//tester la méthode qui affiche les vols en fonction de type de filtre et sa valeur
Console.WriteLine("**** Get Flights ****");
fm.GetFlights("Destination", "Madrid");
fm.GetFlights("EstimatedDuration", "100");

//Afficher les dates et les destinations des vols d’un avion passé en paramètre
Console.WriteLine("**** Show Flight Details ****");
fm.ShowFlightDetails(TestData.BoingPlane);

//tri desc selon date
//Retourner les Vols ordonnés par EstimatedDuration du plus long au plus court
Console.WriteLine("**** Ordered Duration Flights ****");
foreach (Flight f in fm.OrderedDurationFlights())
    Console.WriteLine(f); ;
