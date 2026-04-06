using System;
using UnityEngine;

[Serializable]
public class Enemy : MonoBehaviour
{
    public DamageType resistances = DamageType.Fire | DamageType.Ice;
    private float _health;

    public void TakeDamage(float amount, DamageType type)
    {

        if ((resistances & type) != 0)
        {
            amount *= .5f; // Resistenza: dimezza il danno
            Debug.Log($"Resisted {type}");
        }

        _health -= amount;
    }
}