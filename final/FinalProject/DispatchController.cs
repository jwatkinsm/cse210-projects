public class DispatchController
{
    private const string LogFilePath = "shipment_logs.txt";
    public static void OptimizeAndAssign(Cargo shipment, DeliveryRoute route, FleetManager fleet)
    {
         List<Vehicle> eligibleVehicles = new List<Vehicle>();
        List<double> computedCosts = new List<double>();

        foreach (var vehicle in fleet.GetAvailableVehicles())
        {
            if (shipment.GetRefrigeration && !(vehicle is RefrigeratedVan)) continue;
            if (vehicle is DeliveryDrone drone && shipment.GetWeight > drone.MaxWeightLimitKg) continue;

            if (!vehicle.CanHandleRoute(route))
            {
                Console.WriteLine($"  [INCOMPATIBLE] Unit {vehicle.VehicleId} cannot navigate route parameters.");
                continue;
            }

             double estimatedFuel = vehicle.CalculateFuelRequired(route);

              if (vehicle.CurrentFuel >= estimatedFuel)
            {
                eligibleVehicles.Add(vehicle);
                computedCosts.Add(estimatedFuel);
            }
        }

        if (eligibleVehicles.Count == 0)
        {
            Console.WriteLine("\n[ALERT] No qualified fleet vehicles have sufficient fuel for this delivery route.");
            return;
        }

        Console.WriteLine("\nAvailable Options for Assignment:");
        for (int i = 0; i < eligibleVehicles.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            eligibleVehicles[i].DisplayFleetStatus();
            Console.WriteLine($"   Estimated Trip Cost: {computedCosts[i]:F2} L/Units");
        }

        Console.Write($"\nSelect an option index (1-{eligibleVehicles.Count}) or 0 to cancel dispatch: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= eligibleVehicles.Count)
        {
            int index = choice - 1;
            Vehicle selectedVehicle = eligibleVehicles[index];
            double tripCost = computedCosts[index];

            selectedVehicle.LoadCargo(shipment);
            Console.WriteLine($"\n[SUCCESS] Shipment loaded onto Fleet Unit {selectedVehicle.VehicleId}.");
            
            try
            {
                using (StreamWriter sw = File.AppendText(LogFilePath))
                {
                    string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                                     $"ID: {shipment.GetTracking} | " +
                                     $"Weight: {shipment.GetWeight}kg | " +
                                     $"Dest: {route._destination} ({route._distance}km) | " +
                                     $"Assigned Unit: {selectedVehicle.VehicleId} | " +
                                     $"Est Cost: {tripCost:F2}";
                    sw.WriteLine(logLine);
                }
                Console.WriteLine("[INFO] Historical entry appended to shipment_logs.txt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARNING] Failed to write to log file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\n[CANCELLED] Dispatch deployment aborted by user request.");
        }
    }
}