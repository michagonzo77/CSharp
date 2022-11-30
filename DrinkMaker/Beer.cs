class Beer : Drink
{
    public string Brewery;
    public double ABV;
    public Beer(string brewery, int abv) : base("Beer", "Amber", 42.00, true, 100)
    {
        Brewery = brewery;
        ABV = abv;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine(Brewery);
        Console.WriteLine(ABV);
    }
}