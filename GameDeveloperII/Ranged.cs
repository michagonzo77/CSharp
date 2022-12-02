class Ranged : Enemy
{
    int Distance;
    public Ranged() : base("Ranged Fighter")
    {
        Distance = 5;
        Attacks.Add(new Attack("Shoot Arrow", 20));
        Attacks.Add(new Attack("Throw Knife", 15));
    }
    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"Ranged Fighter has dashed and it's distance is now {Distance}");
    }
    public override Attack? RandomAttack()
    {
        if (Distance < 10){
            Console.WriteLine($"You are too close.");
            return null;
        } else {
            return base.RandomAttack();
        }
    }
}