// Readonly struct immutabile per rappresentare danni
using UnityEngine;

public readonly struct Damage
{
    public float Amount { get; }
    public DamageType type { get; }
    public Vector3 HitPoint { get; }
    public Vector3 HitNormal { get; }

    public Damage (float amount, DamageType type, Vector3 hitPoint, Vector3 hitNormal)
    {
        Amount = amount;
        this.type = type;
        HitPoint = hitPoint;
        HitNormal = hitNormal;
    }

    // Metodo readonly che crea varianti
    public readonly Damage WithMultiplier(float multiplier) =>
        new Damage(Amount * multiplier, type, HitPoint, HitNormal);
}

public class EnemyDamage : MonoBehaviour
{
    public void TakeDamage(in Damage Damage) // Passato per riferimento (nessuna copia)
    {
        
    }
}