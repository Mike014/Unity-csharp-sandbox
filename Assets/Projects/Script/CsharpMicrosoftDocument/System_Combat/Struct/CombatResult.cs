public struct CombatResult
{
    public float totalDamage { get; set; }
    public bool wasCritical { get; set; }
    public StatusEffect appliedStatus { get; set; }
}