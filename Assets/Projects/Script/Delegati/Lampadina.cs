using UnityEngine;

public class Lampadina : MonoBehaviour
{
    // Riferimento al telecomando per potersi iscrivere
    public Telecomando ilMioTelecomando;

    // Chiamata quando l'oggetto si attiva
    void OnEnable()
    {
        // 4. ISCRIZIONE (Subscribe)
        // Usiamo += per dire "Aggiungi la mia funzione Accendi alla lista del telecomando"
        // NOTA: Non ci sono le parentesi () dopo Accendi! Stiamo passando il riferimento.
        ilMioTelecomando.OnPulsantePremuto += Accendi;
    }

    void Accendi()
    {
        Debug.Log("Lampadina: Click! Mi sono accesa/spenta.");
    }

    // Questa funzione viene chiamata quando l'oggetto si disattiva o viene distrutto
    void OnDisable()
    {
        // Disiscrizione 
        // Se non lo facciamo, il telecomando proverà a chiamare una lampadina fantasma (Memory Leak)
        ilMioTelecomando.OnPulsantePremuto -= Accendi;
    }
}
