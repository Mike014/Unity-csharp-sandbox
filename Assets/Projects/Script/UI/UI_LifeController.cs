using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image healthBar;  // La barra rossa in Game
    
    private LifeController lifeController;

    void Start()
    {
        // Ottieni il riferimento al LifeController
        lifeController = GetComponentInParent<LifeController>();

        // Sottoscrivi all'evento
        if (lifeController != null)
        {
            lifeController.onHealthChanged.AddListener(UpdateHealthBar);
        }
    }

    /// <summary>
    /// Aggiorna SOLO il fillAmount della barra
    /// </summary>
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        // Calcola la percentuale (0 a 1)
        float healthPercentage = currentHealth / maxHealth;

        // SOLO questa riga: modifica il fillAmount
        healthBar.fillAmount = healthPercentage;

        Debug.Log($"Vita: {currentHealth}/{maxHealth} → FillAmount: {healthPercentage}");
    }
}