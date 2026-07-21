public class FleetManager
{
    private List<Vehicle> _activeFleet = new List<Vehicle>();
    private const string FilePath = "fleet_data.txt";
    public void AddVehicle(Vehicle v) => _activeFleet.Add(v);
    public List<Vehicle> GetAvailableVehicles() => _activeFleet;
    public void PrintFleetAudit()
    {
        Console.WriteLine("\n=== Active Fleet Audit ===");
        foreach (var v in _activeFleet) v.DisplayFleetStatus();
    }
    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var v in _activeFleet)
                {
                    if (v is CargoTruck truck)
                    {
                        writer.WriteLine($"Truck,{truck.VehicleId},{truck.CurrentFuel},{truck._numberOfAxles},{v.CanHandleRoute(new DeliveryRoute("",0,true))}");
                    }
                    else if (v is RefrigeratedVan van)
                    {
                        writer.WriteLine($"Van,{van.VehicleId},{van.CurrentFuel}");
                    }
                    else if (v is DeliveryDrone drone)
                    {
                        writer.WriteLine($"Drone,{drone.VehicleId},{drone.CurrentFuel}");
                    }
                }
            }
            Console.WriteLine("[SUCCESS] Fleet Data saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Could not save data: {ex.Message}");
        }
    }
     public void LoadFromFile()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("[INFO] No existing fleet record found. Starting fresh.");
            return;
        }

        try
        {
            _activeFleet.Clear(); 
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length < 3) continue;

                string type = data[0];
                string id = data[1];
                double.TryParse(data[2], out double fuel);

                if (type == "Truck" && data.Length >= 5)
                {
                    int.TryParse(data[3], out int axles);
                    bool.TryParse(data[4], out bool has4Wd);
                    _activeFleet.Add(new CargoTruck(id, fuel, axles, has4Wd));
                }
                else if (type == "Van" && data.Length >= 5)
                {
                    double.TryParse(data[3], out double targetTempF);
                    double.TryParse(data[4], out double insulationCm);
                    _activeFleet.Add(new RefrigeratedVan(id, fuel, targetTempF, insulationCm));
                }
                else if (type == "Drone")
                {
                    _activeFleet.Add(new DeliveryDrone(id, fuel));
                }
            }
            Console.WriteLine($"[SUCCESS] Loaded {_activeFleet.Count} vehicles from persistent storage.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Could not load data: {ex.Message}");
        }
    }
}
