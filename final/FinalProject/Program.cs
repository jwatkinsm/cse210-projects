using System;


class Program
{
    static void Main(string[] args)
    {
        FleetManager centralFleet = new FleetManager();

        centralFleet.LoadFromFile();

        if (centralFleet.GetAvailableVehicles().Count == 0)
        {
            centralFleet.AddVehicle(new CargoTruck("TRK-77", 300.0, 3, false ));
            centralFleet.AddVehicle(new RefrigeratedVan("COLD-02", 80.0, -4.0, 8.0)); // -4°F deep freeze
            centralFleet.AddVehicle(new DeliveryDrone("DRN-alpha", 50.0));
            centralFleet.AddVehicle(new CargoTruck("TRK-OffRoad", 400.0, 2, true));
        }

        bool runProgram = true;
        while (runProgram)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("    LOGISTICS FLEET TRACKER HARDWARE    ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. View Current Fleet Audit");
            Console.WriteLine("2. Dispatch Custom Shipment Route");
            Console.WriteLine("3. Add New Vehicle to Fleet");
            Console.WriteLine("4. Save System Registry");
            Console.WriteLine("5. Exit System Engine");
            Console.Write("Select an operation option (1-5): ");

            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    centralFleet.PrintFleetAudit();
                    break;

                case "2":
                    Console.WriteLine("\n--- Step A: Configure Your Cargo Load ---");
                    Console.Write("Enter unique Tracking ID: (or press Enter to auto-generate): ");
                    string id = Console.ReadLine();

                    // RANDOM GENERATOR LOGIC: If input is blank
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Random rand = new Random();
                        int randomNumber = rand.Next(0000000, 9999999);
                        id = $"SHP-{randomNumber}";
                        Console.WriteLine($"[INFO] Auto-generated Tracking ID: {id}");
                    }
                    
                    Console.Write("Enter weight load configuration (kg): ");
                    double.TryParse(Console.ReadLine(), out double weight);
                    
                    Console.Write("Does this bundle require cold-chain refrigeration? (y/n): ");
                    bool needsCooling = Console.ReadLine()?.ToLower() == "y";

                    Cargo shipment = new Cargo(id, weight, needsCooling);

                    Console.WriteLine("\n--- Step B: Configure Destination Parameters ---");
                    Console.Write("Enter destination name: ");
                    string dest = Console.ReadLine();
                    
                    Console.Write("Enter transit travel distance (km): ");
                    double.TryParse(Console.ReadLine(), out double dist);
                    
                    Console.Write("Is the destination situated in rough/mountain terrain? (y/n): ");
                    bool isRough = Console.ReadLine()?.ToLower() == "y";

                    DeliveryRoute route = new DeliveryRoute(dest, dist, isRough);

                    Console.WriteLine("\n--- Step C: Evaluating Optimal Infrastructure ---");
                    Console.WriteLine($"Destination: {route._destination} ({route._distance}km, Rough Terrain: {route._isRoughTerrain})");
                    DispatchController.OptimizeAndAssign(shipment, route, centralFleet);
                    break;

                case "3":
                    Console.WriteLine("\n--- Select Vehicle Type to Add ---");
                    Console.WriteLine("1. Cargo Truck");
                    Console.WriteLine("2. Refrigerated Van");
                    Console.WriteLine("3. Delivery Drone");
                    Console.Write("Choice (1-3): ");
                    string vType = Console.ReadLine();

                    Console.Write("Enter unique Vehicle ID: ");
                    string vId = Console.ReadLine();
                    Console.Write("Enter maximum fuel/battery capacity: ");
                    double.TryParse(Console.ReadLine(), out double cap);

                    if (vType == "1")
                    {
                        Console.Write("Enter number of axles: ");
                        int.TryParse(Console.ReadLine(), out int axles);
                        Console.Write("Is it 4WD capable? (y/n): ");
                        bool has4Wd = Console.ReadLine()?.ToLower() == "y";
                        
                        centralFleet.AddVehicle(new CargoTruck(vId, cap, axles, has4Wd));
                        Console.WriteLine($"[SUCCESS] Heavy Truck {vId} added to inventory.");
                    }
                    else if (vType == "2")
                    {
                        Console.Write("Enter target temperature (°F): ");
                        double.TryParse(Console.ReadLine(), out double temp);
                        Console.Write("Enter insulation thickness (cm): ");
                        double.TryParse(Console.ReadLine(), out double insulation);
                        
                        centralFleet.AddVehicle(new RefrigeratedVan(vId, cap, temp, insulation));
                        Console.WriteLine($"[SUCCESS] Refrigerated Van {vId} added to inventory.");
                    }
                    else if (vType == "3")
                    {
                        centralFleet.AddVehicle(new DeliveryDrone(vId, cap));
                        Console.WriteLine($"[SUCCESS] UAV Drone {vId} added to inventory.");
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Invalid vehicle type selection.");
                    }
                     centralFleet.SaveToFile();
                    break;

                 case "4":
                    centralFleet.SaveToFile();
                    break;

                case "5":
                    centralFleet.SaveToFile();
                    runProgram = false;
                    Console.WriteLine("\nShutting down Fleet Tracker Engine safely. Goodbye.");
                    break;

                default:
                    Console.WriteLine("\nInvalid option selection string. Please choose between indices 1-5.");
                    break;
            }
        }
    }
}