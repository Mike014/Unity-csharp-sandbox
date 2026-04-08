using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float fireRate;
    protected float lastFireTime;

    // Logica comune a tutte le armi
    public bool CanFire() => Time.time >= lastFireTime + fireRate;

    // Implementazione specifica per tipo di arma
    public abstract void Fire(Vector3 target);
    public abstract void Reload();
}
