
public readonly struct DamageInstance
{
    public float baseDamage { get; }
    public DamageType damageTypes { get; }
    public StatusEffect? inflictedStatus { get; }
    public float criticalChance { get; }

    public DamageInstance(float baseDamage, DamageType damageTypes, StatusEffect? inflictedStatus, float criticalChance)
    {
        this.baseDamage = baseDamage;
        this.damageTypes = damageTypes;
        this.inflictedStatus = inflictedStatus;
        this.criticalChance = criticalChance;
    }

    public float CalculateFinalDamage(in DefenseStats defenses)
    {
        float finalDamage = baseDamage;

        // Per ogni tipo di danno nell'attacco, applica il moltiplicatore
        // Se resistente a QUALSIASI tipo nell'attacco: dimezza
        if ((damageTypes & defenses.resistances) != 0)
        {
            finalDamage *= 0.5f;
        }

        // Se debole a QUALSIASI tipo nell'attacco: raddoppia
        if ((damageTypes & defenses.weaknesses) != 0)
        {
            finalDamage *= 2.0f;
        }
        
        // Logica da implementare
        return finalDamage; 
    }

    public DamageInstance WithCritical()
    {
        return new DamageInstance(this.baseDamage * 2, this.damageTypes, this.inflictedStatus, 1.0f);
    }
}