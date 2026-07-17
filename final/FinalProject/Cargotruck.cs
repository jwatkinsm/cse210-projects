public class CargoTruck : Vehicle
{
    public int _numberOfAxles{get;}
    public CargoTruck(string id, double fuelCapacity, int axles) : base(id, fuelCapacity) {_numberOfAxles = axles;}
    public override bool CanHandleRoute(DeliveryRoute route) => !route._isRoughTerrain;
    public override double CalculateFuelRequired(DeliveryRoute route)
    {
        double cargoWeight = 0;
        double AxleFuel = 0.25 + (_numberOfAxles * 0.05);
        foreach( var item in LoadedCargo) cargoWeight+= item.GetWeight;
        return (route._distance * 0.35) + (cargoWeight * 0.001) + AxleFuel;
    }
}