class Drink
{
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;
    
    // We need a basic constructor that takes all these features in
    public Drink(string name, string color, double temp, bool isCarb, int calories)
    {
        Name = name;
        Color = color;
        Temperature = temp;
        IsCarbonated = isCarb;
        Calories = calories;
    }
    public virtual void ShowDrink()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Color);
        Console.WriteLine(Temperature);
        Console.WriteLine(IsCarbonated);
        Console.WriteLine(Calories);
    }
}