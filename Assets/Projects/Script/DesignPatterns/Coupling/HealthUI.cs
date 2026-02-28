using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text UpdateHealthText;

    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealth;
        PlayerHealth.OnGameOver += ShowGameOver;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealth;
        PlayerHealth.OnGameOver -= ShowGameOver;
    }

    void Start()
    {
        UpdateHealthText.text = PlayerHealth.currentHealth.ToString();
    }

    private void UpdateHealth(int newHealth)
    {
        UpdateHealthText.text = newHealth.ToString();
    }

    private void ShowGameOver()
    {
        UpdateHealthText.text = "GAME OVER";
    }
}