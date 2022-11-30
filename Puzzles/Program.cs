// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


static string HeadsOrTails()
{
    Random rand = new Random();
    Console.WriteLine("Test Your Luck");
    return rand.Next(0,2) == 0 ? "It Was Heads": "It Was Tails";
}
Console.WriteLine(HeadsOrTails());

static int DiceRoll(int number)
{
    Random rand = new Random();
    return rand.Next(1,number);
}

// Console.WriteLine(DiceRoll());

// List<int> RollDiceFourTimes()
// {
//     List<int> values = new List<int>(4);
//     values.Add(DiceRoll());
//     values.Add(DiceRoll());
//     values.Add(DiceRoll());
//     values.Add(DiceRoll());
//     return values;
// }

// List<int> diceRolls = RollDiceFourTimes();
// int max = 0;
// foreach(int diceRoll in diceRolls)
// {
//     if (diceRoll > max){
//         max = diceRoll;
//     }
//     Console.WriteLine(diceRoll);
// }
// Console.WriteLine(max);

// static string RollUntil(int number)
// {
//     if (number < 1 || number > 6)
//     {
//         return "Invalid Number";
//     }
//     int count = 1;
//     int result = DiceRoll();
//     while(result != number)
//     {
//         result = DiceRoll();
//         count++;
//     }
//     return $"Rolled a {number} after {count} tries";
// }

// Console.WriteLine(RollUntil(4));


static string tellUser(string diceInput)
{
    if(diceInput == "6")
    {
        Console.WriteLine($"You Rolled A {DiceRoll(6)}");
    }
    if(diceInput == "12")
    {
        Console.WriteLine($"You Rolled A {DiceRoll(12)}");
    }
    if(diceInput == "20")
    {
        Console.WriteLine($"You Rolled A {DiceRoll(20)}");
    }
    Console.WriteLine("Would you like to roll again?");
    string yesOrNo = Console.ReadLine();
    if (yesOrNo == "yes")
    {
        Console.WriteLine("Would you like to roll a 6-sided, 12-sided, or 20-sided die?");
        diceInput = Console.ReadLine();
        tellUser(diceInput);
    } else Console.WriteLine("Thanks for Playing!");
    return "null";
}

Console.WriteLine("Would you like to roll a 6-sided, 12-sided, or 20-sided die?");
string diceInput = Console.ReadLine();

tellUser(diceInput);
