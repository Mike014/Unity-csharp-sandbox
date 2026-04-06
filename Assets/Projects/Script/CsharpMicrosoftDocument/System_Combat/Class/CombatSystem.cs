using System;
using UnityEngine;

public static class CombatSystem
{
    static bool ExecuteAttack(in DamageInstance damage, in DefenseStats defenses, out CombatResult result)
    {
        // Calcola danno finale
        float finalDamage = damage.baseDamage;

        // Applica moltiplicatori di difesa
        if ((damage.damageTypes & defenses.resistances) != 0)
        {
            finalDamage *= 0.5f;
        }
        if ((damage.damageTypes & defenses.weaknesses) != 0)
        {
            finalDamage *= 2.0f;
        }

        // Determina se è critico (Random)
        bool isCritical = false;
        System.Random random = new System.Random();
        if ((float)random.NextDouble() < damage.criticalChance)
        {
            isCritical = true;
            finalDamage *= 2.0f;
        }

        // Applica status se presente
        StatusEffect appliedStatus = StatusEffect.None;
        if (damage.inflictedStatus.HasValue)
        {
            appliedStatus = damage.inflictedStatus.Value;
        }

        // Imposta il risultato
        result = new CombatResult
        {
            totalDamage = finalDamage,
            wasCritical = isCritical,
            appliedStatus = appliedStatus
        };

        // Restituisce bool (true se l'attacco ha successo)
        // L'attacco ha successo se causa danno > 0
        return finalDamage > 0;
    }

    public static DamageInstance CreateAttack(AttackType type)
    {
        if (!Enum.IsDefined(typeof(AttackType), type))
        {
            Debug.LogError($"Invalid attack type: {type}");
            return new DamageInstance(0f, DamageType.None, null, 0f);
        }

        switch (type)
        {
            case AttackType.BasicStrike:
                return new DamageInstance(20f, DamageType.Physical, null, 0.1f);

            case AttackType.Fireball:
                return new DamageInstance(35f, DamageType.Fire, StatusEffect.Burning, 0.15f);

            case AttackType.IceShock:
                return new DamageInstance(30f, DamageType.Ice | DamageType.Lightning, StatusEffect.Frozen, 0.2f);

            default:
                return new DamageInstance(0f, DamageType.None, null, 0f);
        }
    }

    public static bool TryParseAttackType(int input, out AttackType result)
    {
        if (Enum.IsDefined(typeof(AttackType), input))
        {
            result = (AttackType)input;
            return true;
        }

        result = default;
        return false;  // ← Non dimenticare: false quando fallisce!
    }
}


