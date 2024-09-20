// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

Plane plane = new Plane();
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Airbus;

//Plane plane1 = new Plane(100, new DateTime(2024,10,23,12,22,00), PlaneType.Boing);

//Object Initializer
Plane plane1 = new Plane { Capacity = 200, PlaneType = PlaneType.Airbus };

Console.WriteLine(plane1.Capacity);
Console.WriteLine(plane1);

Passenger passenger = new Passenger(FirstName="yousra", LastNAme="chaieb", EmailAdress="yousra.chaieb@esprit.tn");

Console.WriteLine("**** Check Profile ****");
Console.WriteLine(passenger.checkProfile("yousra","chaieb");
Console.WriteLine(passenger.checkProfile("yousra", "chaieb","abc");