public class DeliveryRoute
{
    public string _destination { get; }
    public double _distance { get; }
    public bool _isRoughTerrain { get; }

    public DeliveryRoute(string destination, double distance, bool isRoughTerrain)
    {
        _destination = destination;
        _distance = distance;
        _isRoughTerrain = isRoughTerrain;
    }

}