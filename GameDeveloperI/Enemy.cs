class Enemy 
{
    public string Name;
    private int HealthAmount;
    public int _HealthAmount {get {return HealthAmount;}}
    public List<Attack> Attacks;

    public Enemy(string n)
    {
        Name = n;
        HealthAmount = 100;
        Attacks = new List<Attack>();
    }
    public void RandomAttack()
    {
        Random rand = new Random();
        int attackIdx = rand.Next(0, Attacks.Count);
        Console.WriteLine($"Enemy {Name} has used attack {Attacks[attackIdx].Name} and has hit for {Attacks[attackIdx].DamageAmount}");
    }
    public void AddAttack(Attack attack)
    {
        Attacks.Add(attack);
    }
}
