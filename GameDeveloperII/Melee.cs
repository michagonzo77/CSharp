class Melee : Enemy
{
    public Melee() : base("Melee Fighter", 120)
    {
        Attacks.Add(new Attack("Punch", 20));
        Attacks.Add(new Attack("Kick", 15));
        Attacks.Add(new Attack("Tackle", 25));
    }
    public void Rage()
    {
        Attack RageItUp = base.RandomAttack();
        RageItUp.DamageAmount += 10;
        Console.WriteLine($"{Name} has RAGED UP and increase damage to {RageItUp.Name} by 10 extra DMG!");
        Console.WriteLine($"{RageItUp.Name} has hit for {RageItUp.DamageAmount}");
    }
}