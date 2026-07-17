public class RefrigeratedVan : Vehicle
{
    private double _targetTemperature;
    private double _insulationThickness;
     public RefrigeratedVan(string id, double fuelCapacity, double targetTempF, double insulationCm) 
        : base(id, fuelCapacity) 
    { 
        _targetTemperature = targetTempF;
        _insulationThickness = insulationCm;
    }
    public override bool CanHandleRoute(DeliveryRoute route) => true;
    public override double CalculateFuelRequired(DeliveryRoute route)
    {
         double totalWeight = 0;
        foreach (var item in LoadedCargo) totalWeight += item.GetWeight;

        double fuelBurn = 0.15 + (totalWeight * 0.001);
        double travelFuel = route._distance * fuelBurn;

          double coolingLoad = Math.Max(1, 77.0 - _targetTemperature); 
        double coolingFuel = (coolingLoad * 0.027) / (_insulationThickness * 0.5);

        return travelFuel + (route._distance * coolingFuel);
    }
}
