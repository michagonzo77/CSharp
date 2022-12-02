class Melee : Enemy
{
    public Melee() : base("Melee Fighter", 120)
    {
        Attacks.Add(new Attack("Punch", 20));
        Attacks.Add(new Attack("Kick", 15));
        Attacks.Add(new Attack("Tackle", 25));
    }
    public Attack? Rage()
    {
        Attack? RageItUp = base.RandomAttack();
        if (RageItUp == null){
            return null;
        }
        RageItUp.DamageAmount += 10;
        Console.WriteLine($"{Name} has RAGED UP and increased damage to {RageItUp.Name} by 10 extra DMG!");
        Console.WriteLine($"{RageItUp.Name} has hit for {RageItUp.DamageAmount}");
        return RageItUp;
    }
}