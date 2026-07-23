public abstract class Vehicle
{
    private string vehicleId;
    private double currentFuel;
    private double maxFuelCapacity;
    private List<Cargo> loadedCargo = new List<Cargo>();

    public string VehicleId => vehicleId;
    public double CurrentFuel => currentFuel;
    public List<Cargo> LoadedCargo => loadedCargo;

    protected Vehicle(string id, double fuelCapacity)
    {
        vehicleId = id;
        maxFuelCapacity = fuelCapacity;
        currentFuel = fuelCapacity;
    }

    public void LoadCargo(Cargo item) => loadedCargo.Add(item);

     public void ConsumeFuel(double amount)
        {
            currentFuel = Math.Max(0.0, currentFuel - amount);
        }

        public void Refuel()
        {
            currentFuel = maxFuelCapacity;
            Console.WriteLine($"  [INFO] Vehicle {VehicleId} has been refueled to {maxFuelCapacity}L/Units.");
        }

    public abstract bool CanHandleRoute(DeliveryRoute route);
    public abstract double CalculateFuelRequired(DeliveryRoute route);

    public virtual void DisplayFleetStatus()
    {
        Console.WriteLine($"[ID: {VehicleId}] Fuel: {currentFuel}L | Cargo Items: {loadedCargo.Count}");
    }
}