// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Vehicle Ferrari = new Vehicle("Lucky", 2, "Orange", true, 220);
Vehicle OneWheel = new Vehicle("Balance", 1, "Black", false, 25);
Vehicle RollerBlades = new Vehicle("Wheels", "Red");
Vehicle Parachute = new Vehicle("Floater", "Yellow");

List<Vehicle> AllVehicles = new List<Vehicle>() {Ferrari, OneWheel, RollerBlades, Parachute};

foreach(Vehicle vehicle in AllVehicles)
{
    vehicle.ShowInfo();
}

Ferrari.Travel(350);
Ferrari.ShowInfo();