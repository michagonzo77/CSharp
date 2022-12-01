public class Horse : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Horse(string n, string c, int t, string ft) : base(n, 2, c, false, t) 
    {
        FuelType = ft;
        FuelTotal = 50;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"Fed {Name} some {FuelType}.");
    }
}