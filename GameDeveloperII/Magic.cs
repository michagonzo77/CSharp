class Magic : Enemy
{
    public Magic() : base("Magic Caster", 80)
    {
        Attacks.Add(new Attack("Fireball", 25));
        Attacks.Add(new Attack("Shield", 0));
        Attacks.Add(new Attack("Staff Strike", 15));
    }
    public void Heal(Enemy enemy)
    {
        enemy._HealthAmount += 40;
        Console.WriteLine($"{Name} has healed {enemy.Name} by 40");
        Console.WriteLine($"{enemy.Name} now has {enemy._HealthAmount} health");
    }
}