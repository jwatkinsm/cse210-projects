public class DeliveryDrone : Vehicle
{
    public double MaxWeightLimitKg => 15.0;

    public DeliveryDrone(string id, double initialBatteryCapacity) : base(id, initialBatteryCapacity) {}

    public override bool CanHandleRoute(DeliveryRoute route) => route._distance <= 40.0;

    public override double CalculateFuelRequired(DeliveryRoute route) 
    {
        double totalWeight = 0;
        foreach (var item in LoadedCargo) totalWeight += item.GetWeight;

        double batteryBurn = 0.80 + (totalWeight * 0.15);
        return route._distance * batteryBurn;
    }
    public override void DisplayFleetStatus() 
    { 
        Console.Write("[UAV Drone] "); base.DisplayFleetStatus(); 
    }
}