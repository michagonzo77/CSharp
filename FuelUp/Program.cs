// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Bicycle Cycle = new Bicycle("Fuji", "Red", 30);
Car Volvo = new Car("Lucky", 5, "Silver", false, 140, "Gas");
Horse Ed = new Horse("Ed", "Brown", 40, "fart");

// Cannot create an instance of an abstract class.
// Vehicle Tommy = new Vehicle()

List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(Cycle);
AllVehicles.Add(Volvo);
AllVehicles.Add(Ed);

List<INeedFuel> AllNeedFuel = new List<INeedFuel>();
foreach(Vehicle oneVehicle in AllVehicles)
{
    if(oneVehicle is INeedFuel)
    {
        AllNeedFuel.Add((INeedFuel)oneVehicle);
    }
}

foreach(INeedFuel f in AllNeedFuel)
{
    Console.WriteLine(f.FuelType);
    Console.WriteLine(f.FuelTotal);
}