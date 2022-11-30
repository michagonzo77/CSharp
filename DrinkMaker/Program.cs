// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Water Hydrate = new Water();
Beer Drunk = new Beer("Dog Fish Head", 7);
Coffee CafeConLeche = new Coffee("Dark", "Colombia");


List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(Hydrate);
AllBeverages.Add(Drunk);
AllBeverages.Add(CafeConLeche);

foreach(Drink beverage in AllBeverages)
{
    beverage.ShowDrink();
}
// Can't mix types. Can't change Water to Coffee.
// Coffee MyDrink = new Water();