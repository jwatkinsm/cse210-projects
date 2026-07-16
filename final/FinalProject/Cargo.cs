using System;

public class Cargo
{
    private string _trackingId;
    private double _weight;
    private bool _requireRefrigeration;
    public string GetTracking => _trackingId;
    public double GetWeight => _weight;
    public bool GetRefrigeration => _requireRefrigeration;

    public Cargo(string id, double weight, bool needsCooling)
    {
        _trackingId= id;
        _weight= weight;
        _requireRefrigeration= needsCooling;
    }
}