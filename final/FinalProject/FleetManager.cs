public class FleetManager
{
    private List<Vehicle> _activeFleet = new List<Vehicle>();
    public void AddVehicle(Vehicle v) => _activeFleet.Add(v);
    public List<Vehicle> GetAvailableVehicles() => _activeFleet;
    public void PrintFleetAudit()
    {
        Console.WriteLine("\n=== Active Fleet Audit ===");
        foreach (var v in _activeFleet) v.DisplayFleetStatus();
    }
}