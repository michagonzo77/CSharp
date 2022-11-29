// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int height = 52;

if (height >= 42 && height < 78)
{
    Console.WriteLine("Ride this thang!");
} else {
    Console.WriteLine("Sorry, you don't meet the requirements.");
} 

bool status = false;

if (status == true)
{
    Console.WriteLine("Order complete!");
} else {
    Console.WriteLine("Order is still in process.");
}

string faveDrink = "cafe con leche";
string drink = "cafe con leche";
int drinkTemp = 101;

if (faveDrink != drink)
{
    Console.WriteLine($"I ordered {faveDrink}");
} else if (drinkTemp <= 86){
    Console.WriteLine("Sorry, this drink is too cold");
} else if (drinkTemp >= 100){
    Console.WriteLine("Are you trying to burn my tongue?");
}