using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // PERCHÉ È SCRITTO COSÌ:
    // 'public static event': Creiamo l'evento globale. È il nostro "megafono".
    // 'Action<int>': Significa che quando urliamo nel megafono, trasmettiamo anche un numero intero (la vita rimasta).
    public static event Action<int> OnHealthChanged;
    public static event Action OnGameOver;
    /*
    Analogia: immagina una lavagna in classe. 
    Ogni studente (istanza) ha il suo quaderno (campi d'istanza). 
    La lavagna invece è una sola per tutta la classe — esiste indipendentemente dagli studenti, e tutti la vedono uguale.
    */

    [SerializeField] private int _startingHealth = 100;
    public static int currentHealth { get; private set; }

    void Awake()
    {
        currentHealth = _startingHealth;
    }

    void Start()
    {
        Debug.Log($"CurrentHealt is : {currentHealth}");
    }

    // Usiamo l'Update solo per testare la funzione premendo Spazio
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            Debug.Log($"CurrentHealth is : {currentHealth}");
        }
    }

    // Questa funzione simula il giocatore che prende danno
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // IL CUORE DEL PATTERN:
        // Il punto interrogativo (?) controlla se c'è almeno uno script in ascolto.
        // Se c'è, '.Invoke' lancia l'evento e trasmette il nuovo valore di salute a tutti.
        OnHealthChanged?.Invoke(currentHealth);
        Debug.Log("Giocatore colpito! Vita: " + currentHealth);

        if(currentHealth <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
