// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Plane plane = new Plane(PlaneType.Airbus, 100, DateTime.Now);
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Airbus;

//Plane plane1 = new Plane(100, new DateTime(2024,10,23,12,22,00), PlaneType.Boing);

//Object Initializer

Plane plane1 = new Plane(PlaneType.Airbus, 200, DateTime.Now);
Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);
Plane plane3 = new Plane(PlaneType.Airbus, 150, new DateTime(2015, 02, 03));


Console.WriteLine(plane1.Capacity);
Console.WriteLine(plane1);

Passenger passenger = new Passenger(FirstName="yousra", LastNAme="chaieb", EmailAdress="yousra.chaieb@esprit.tn");
Console.WriteLine(passenger.checkProfile("yousra", "chaieb"));
Console.WriteLine(passenger.checkProfile("yousra", "chaieb", "abc"));

Console.WriteLine("**** Check Profile ****");
Console.WriteLine(passenger.checkProfile("yousra","chaieb");
Console.WriteLine(passenger.checkProfile("yousra", "chaieb","abc");

Console.WriteLine("**** Passenger Type ****");
Staff s1 = new Staff { FirstName = "staff1"}; 
Passenger p1 = new Passenger();
Traveller t1 = new Traveller { FirstName = "traveller1" };

p1.PassengerType();
s1.PassengerType();
t1.PassengerType();

Console.WriteLine("**** Get Flight Dates ****");
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
foreach (DateTime d in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(d);
}

Console.WriteLine("**** Get Flights ****");
fm.GetFlights("Destination", "Madrid");
fm.GetFlights("EstimatedDuration", "200");

Console.WriteLine("**** Show Flight Details ****");
fm.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("**** Ordered Flight Details ****");
foreach(Flight f in fm.Flights)
