using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private bool _isAlive;
    private bool _isInvulnerable;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    void Awake()
    {

    }

    private void _TakeDamage(float damage)
    {
        // --- GUARD CLAUSES (I buttafuori del metodo) ---
        if (!_isAlive) return; // Se è già morto, ignora.
        if (_isInvulnerable) return; // Se ha lo scudo, ignora.
        if (damage <= 0) return;

        // --- LOGICA PRINCIPALE (Il cuore del metodo) ---
        // Se siamo arrivati qui, siamo SICURI al 100% che il danno va applicato.
        _health -= _damage;
        UpdateHealthUI();
        PlayDamageAnimation();

        if (_health <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        // .. 
    }

    private void PlayDamageAnimation()
    {
        // .. 
    }

    private void Die()
    {
        // ..
    }
}
