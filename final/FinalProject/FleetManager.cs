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
                        writer.WriteLine($"Truck,{truck.VehicleId},{truck.CurrentFuel},{truck._numberOfAxles},{v.CanHandleRoute(new DeliveryRoute("",0,true))},{truck.MaxFuelCapacity}");
                    }
                    else if (v is RefrigeratedVan van)
                        {
                            writer.WriteLine($"Van,{van.VehicleId},{van.MaxFuelCapacity},{van.CurrentFuel},{van.TargetTemp},{van.Insulation}");
                        }
                        else if (v is DeliveryDrone drone)
                        {
                        writer.WriteLine($"Drone,{drone.VehicleId},{drone.MaxFuelCapacity},{drone.CurrentFuel}");
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
                double.TryParse(data[3], out double maxCap);

                if (type == "Truck" && data.Length >= 5)
                {
                    int.TryParse(data[4], out int axles);
                    bool.TryParse(data[5], out bool _4wd);
                    _activeFleet.Add(new CargoTruck(id, fuel, maxCap, axles, _4wd));
                }
                else if (type == "Van" && data.Length >= 5)
                {
                    double.TryParse(data[4], out double targetTempF);
                    double.TryParse(data[5], out double insulationCm);
                    _activeFleet.Add(new RefrigeratedVan(id, fuel, maxCap, targetTempF, insulationCm));
                }
                else if (type == "Drone")
                {
                    _activeFleet.Add(new DeliveryDrone(id, fuel, maxCap));
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
