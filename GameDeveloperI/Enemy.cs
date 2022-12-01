class Enemy 
{
    public string Name;
    private int HealthAmount;
    public int _HealthAmount {get {return HealthAmount;} set {HealthAmount = value;}}
    public List<Attack> Attacks;

    public Enemy(string n)
    {
        Name = n;
        HealthAmount = 100;
        Attacks = new List<Attack>();
    }
    public Enemy(string n, int h)
    {
        Name = n;
        HealthAmount = h;
        Attacks = new List<Attack>();
    }
    public virtual Attack RandomAttack()
    {
        Random rand = new Random();
        int attackIdx = rand.Next(0, Attacks.Count);
        Console.WriteLine($"Enemy {Name} has used attack {Attacks[attackIdx].Name} and has hit for {Attacks[attackIdx].DamageAmount}");
        return Attacks[attackIdx];
    }
    public void OneAttack(Attack attack)
    {
        Console.WriteLine($"Enemy {Name} has used attack {attack.Name} and has hit for {attack.DamageAmount}");
    }
    public void AddAttack(Attack attack)
    {
        Attacks.Add(attack);
    }
}
