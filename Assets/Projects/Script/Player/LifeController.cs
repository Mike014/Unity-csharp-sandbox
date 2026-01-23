using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    // UnityEvent che comunica il danno ricevuto
    //                <currentHealth, maxHealth>
    public UnityEvent<float, float> onHealthChanged;
    public UnityEvent onPlayerDied;

    void Start()
    {
        currentHealth = maxHealth;

        // Cerca UI_LifeController su HealthBar_Image
        UI_LifeController uiController = FindObjectOfType<UI_LifeController>();

        if (uiController != null)
        {
            onHealthChanged.AddListener(uiController.UpdateHealthBar);
            Debug.Log("✅ UI_LifeController trovato e collegato!");
        }
        else
        {
            Debug.LogError("❌ UI_LifeController non trovato!");
        }

        onHealthChanged.Invoke(currentHealth, maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(5F);
        }
    }

    /// <summary>
    /// Applica danno al giocatore
    /// </summary>
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"Danno ricevuto: {damageAmount}. Vita rimanente: {currentHealth}");

        // Notifica l'UI del cambio di vita
        onHealthChanged.Invoke(currentHealth, maxHealth);

        // Controlla se il giocatore è morto
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Il giocatore è morto!");
        onPlayerDied.Invoke();
        // Potresti disabilitare il GameObject o fare altro
        gameObject.SetActive(false);
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
