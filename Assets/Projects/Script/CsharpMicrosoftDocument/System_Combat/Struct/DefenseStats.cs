public readonly struct DefenseStats 
{
    public DamageType resistances { get; }
    public DamageType weaknesses { get; }

    public DefenseStats(DamageType resistances, DamageType weaknesses)
    {
        this.resistances = resistances;
        this.weaknesses = weaknesses;
    }

    public float GetDamageMultiplier(DamageType type)
    {
        if ((resistances & type) != 0)
        {
            return .5f;
        }

        if ((weaknesses & type) != 0)
        {
            return 2.0f;
        }

        return 1.0f;
    }
}

