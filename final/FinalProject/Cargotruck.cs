public class CargoTruck : Vehicle
{
    private bool _fourWheelDrive;
    public int _numberOfAxles{get;}
    public CargoTruck(string id, double fuelCapacity, int axles, bool _4wd) : base(id, fuelCapacity) 
    {
        _numberOfAxles = axles;
        _fourWheelDrive = _4wd;

    }
    public override bool CanHandleRoute(DeliveryRoute route)
    {
        if (route._isRoughTerrain)
        {
            return _fourWheelDrive; // True if it has 4WD, False if it doesn't
        }
        else
        {
            return true; // All trucks can handle paved roads
        }
    }
    public override double CalculateFuelRequired(DeliveryRoute route)
    {
        double cargoWeight = 0;
        double AxleFuel = 0.25 + (_numberOfAxles * 0.05);
        foreach( var item in LoadedCargo) cargoWeight+= item.GetWeight;
        return (route._distance * 0.35) + (cargoWeight * 0.001) + AxleFuel;
    }
    public override void DisplayFleetStatus() 
    { 
        Console.Write($"[Heavy {_numberOfAxles}-Axle Truck | 4WD Capable: {(_fourWheelDrive ? "YES" : "NO")}] "); base.DisplayFleetStatus(); 
    }
}