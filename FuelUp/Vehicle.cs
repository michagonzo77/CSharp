public abstract class Vehicle 
{
    public string Name;
    public int Passengers;
    public string Color;
    public bool HasEngine;
    public int TopSpeed;
    // Setting fields to private and in turn creating a public version with a get method
    // allows for users to still read but not change directly without interacting with
    // methods.
    private int MilesTraveled = 0;
    public int _MilesTraveled {get {return MilesTraveled;}}

    
    public Vehicle(string n, int p, string c, bool h, int t)
    {
        Name = n;
        Passengers = p;
        Color = c;
        HasEngine = h;
        TopSpeed = t;
    }
    public Vehicle(string n, string c)
    {
        Name = n;
        Passengers = 3;
        Color = c;
        HasEngine = true;
        TopSpeed = 160;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Vehicle Name: {Name}");
        Console.WriteLine($"How Many Passengers Fit?: {Passengers}");
        Console.WriteLine($"Vehicle Color: {Color}");
        Console.WriteLine(HasEngine ? "Has Engine" : "No Engine");
        Console.WriteLine($"Vehicle Travels at Most: {TopSpeed}mph");
        Console.WriteLine($"Vehicle Miles Traveled: {MilesTraveled}");
    }
    public void Travel(int distance)
    {
        MilesTraveled += distance;
        Console.WriteLine($"Just traveled {distance}. Total miles traveled: {MilesTraveled}");
    }
}