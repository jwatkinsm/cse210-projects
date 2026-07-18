public class DispatchController
{
    public static void OptimizeAndAssign(Cargo shipment, DeliveryRoute route, FleetManager fleet)
    {
        Vehicle bestMatch = null;
        double lowestFuel = double.MaxValue;

        foreach (var vehicle in fleet.GetAvailableVehicles())
        {
            if (shipment.GetRefrigeration && !(vehicle is RefrigeratedVan)) continue;
            if (vehicle is DeliveryDrone drone && shipment.GetWeight > drone.MaxWeightLimitKg) continue;

            if (vehicle.CanHandleRoute(route))
            {
                double fuelCost = vehicle.CalculateFuelRequired(route);
                if (fuelCost < lowestFuel)
                {
                    lowestFuel = fuelCost;
                    bestMatch = vehicle;
                }
            }
        }

        if (bestMatch != null)
        {
            bestMatch.LoadCargo(shipment);
            Console.WriteLine($"[SUCCESS] {shipment.GetTracking} ({shipment.GetWeight}) assigned to vehicle {bestMatch.VehicleId}");
        }
        else
        {
            Console.WriteLine($"[FAILED] No vehicle qualified for {shipment.GetTracking}");
        }
    }
}