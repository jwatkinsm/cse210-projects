using System;


class Program
{
    static void Main(string[] args)
    {
       Cargo package = new Cargo("BOX-01", 10.5, true);
       Console.WriteLine($"Package 1: {package.GetTracking}, {package.GetWeight}, {package.GetRefrigeration}");

       DeliveryRoute route = new DeliveryRoute("Downtown Clinic", 25.0, false);
    Console.WriteLine($"Route: {route._destination} is {route._distance}km away."); 

    }
}