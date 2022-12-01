public class Car : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Car(string n, int p, string c, bool h, int t, string ft) : base(n, p, c, h, t) 
    {
        FuelType = ft;
        FuelTotal = 1000;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"Fueled the {Name} with {FuelType} to {FuelTotal}.");
    }
}