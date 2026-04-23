using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    // Punto di ingresso pubblico
    // E' il metodo che il mondo esterno chiama
    // Non espone i dettagli interni
    public void Use()
    {
        // Activate();
    }

    // Sandbox method
    // abstract: ogni sottoclasse DEVE implementarla
    // protected: non chiamabile dall'esterno
    protected abstract void Activate();

    // Provided Operations
    // protected: visibili solo alle sottoclassi
    // non virtual: si usano, non si sovrascrivono

    protected void PlaySound(AudioClip clip)
    {
        // Coupling con AudioSource centralizzato qui
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    protected void SpawnEffect(GameObject prefab, Vector3 position)
    {
        // Coupling con il sistema di istanziazione centralizzato qui
        Instantiate(prefab, position, Quaternion.identity);
    }

    protected void ApplyEffect(float value)
    {
        // Coupling con il sistema del pesonaggio centralizzato qui
        // Placeholder
    }
}

public class DashAbility : Ability
{
    [SerializeField] private AudioClip _dashSound;
    [SerializeField] private GameObject _dashEffect;

    protected override void Activate()
    {
        PlaySound(_dashSound);
        SpawnEffect(_dashEffect, transform.position);
        ApplyEffect(10f);
    }
}

public class ShieldAbility : Ability
{
    [SerializeField] private AudioClip _shieldSound;
    [SerializeField] private GameObject _shieldEffect;

    protected override void Activate()
    {
        PlaySound(_shieldSound);
        SpawnEffect(_shieldEffect, transform.position);
        ApplyEffect(50f);
    }
}
