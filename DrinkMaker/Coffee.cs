class Coffee : Drink
{
    public string Roast;
    public string Region;

    public Coffee(string roast, string region) : base("Coffee", "Caramel", 102.00, false, 100)
    {
        Roast = roast;
        Region = region;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine(Roast);
        Console.WriteLine(Region);
    }
}