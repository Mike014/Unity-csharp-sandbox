public class Character 
{
    public string Name { get; private set; }
    public float Health { get; private set; }
    public DefenseStats Defenses { get; private set; }
    public StatusEffect activeStatuses { get; private set; }

    public Character(string name, float health, DefenseStats defenses)
    {
        this.Name = name;
        this.Health = health;
        this.Defenses = defenses;
        this.activeStatuses = StatusEffect.None;
    }

    public bool TakeDamage(in DamageInstance damage, out CombatResult result)
    {
        result = default;
        return false;
    }

    public bool HasStatus(StatusEffect status)
    {
        return (activeStatuses & status) != 0;
    }

    public void ClearStatus(StatusEffect status)
    {
        activeStatuses &= ~status;
    }
}
