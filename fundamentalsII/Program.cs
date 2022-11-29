// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] firstNine = {0,1,2,3,4,5,6,7,8,9};
string[] fourNames = {"Tim", "Martin", "Nikki", "Sara"};
Random rand = new Random();
bool[] trueOrFalse = new bool[10];
for (int i = 0; i < trueOrFalse.Length; i++){
    trueOrFalse[i] = rand.Next(0,2) == 0 ? true: false;
    // > (Int32.MaxValue / 2);
    // trueOrFalse[i] = (i % 2 == 0);
}
foreach(bool value in trueOrFalse){
    Console.WriteLine(value);
}

List<string> iceCream = new List<string>(5);
iceCream.Add("Chocolate");
iceCream.Add("Vanilla");
iceCream.Add("Strawberry");
iceCream.Add("Cookie Dough");
iceCream.Add("Rocky Road");

foreach(string flavor in iceCream){
    Console.WriteLine(flavor);
}

Console.WriteLine(iceCream.Count);
Console.WriteLine(iceCream[2]);
iceCream.RemoveAt(2);

foreach(string flavor in iceCream){
    Console.WriteLine(flavor);
}

Console.WriteLine(iceCream.Count);

Dictionary<string,string> favoriteIceCream = new Dictionary<string,string>();
for(int i = 0; i < fourNames.Length; i++){
    favoriteIceCream.Add(fourNames[i],iceCream[rand.Next(0,4)]);
}
Console.WriteLine(favoriteIceCream);

foreach(KeyValuePair<string,string> entry in favoriteIceCream)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}