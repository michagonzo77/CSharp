// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Enemy Ninja = new Enemy("Bruce");
Attack Punch = new Attack("Hyper Punch", 30);
Attack Kick = new Attack("Low Blow", 15);
Attack Sword = new Attack("Slice and Dice", 40);

// Ninja.Attacks.Add(Punch);
// Ninja.Attacks.Add(Kick);
// Ninja.Attacks.Add(Sword);

foreach(Attack attack in Ninja.Attacks)
{
    Console.WriteLine(attack.Name);
    Console.WriteLine(attack.DamageAmount);
}

Ninja.AddAttack(Punch);
Ninja.AddAttack(Kick);
Ninja.AddAttack(Sword);

Ninja.RandomAttack();
