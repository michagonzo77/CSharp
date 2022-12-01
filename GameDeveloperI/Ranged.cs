class Ranged : Enemy
{
    int Distance;
    public Ranged(int d = 5) : base("Ranged Fighter")
    {
        Distance = d;
        Attacks.Add(new Attack("Shoot Arrow", 20));
        Attacks.Add(new Attack("Throw Knife", 15));
    }
    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"Ranged Fighter has dashed and it's distance is now {Distance}");
    }
    public override Attack RandomAttack()
    {
        if (Distance < 10){
            Console.WriteLine($"You are too close.");
            return null;
        } else {
            Random rand = new Random();
            int attackIdx = rand.Next(0, Attacks.Count);
            Console.WriteLine($"Enemy {Name} has used attack {Attacks[attackIdx].Name} and has hit for {Attacks[attackIdx].DamageAmount}");
            return Attacks[attackIdx];
        }
    }
}