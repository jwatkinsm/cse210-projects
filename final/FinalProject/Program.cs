using System;


class Program
{
    static void Main(string[] args)
    {
      FleetManager centralFleet = new FleetManager();
        centralFleet.AddVehicle(new CargoTruck("TRK-77", 300.0, 3, false));
        centralFleet.AddVehicle(new RefrigeratedVan("COLD-02", 80.0, -4.0, 8.0)); // -4°F deep freeze
        centralFleet.AddVehicle(new DeliveryDrone("DRN-alpha", 50.0));

        centralFleet.PrintFleetAudit();

    }
}