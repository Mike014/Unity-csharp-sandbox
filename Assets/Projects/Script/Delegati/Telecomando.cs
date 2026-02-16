using UnityEngine;
using System;

public class Telecomando : MonoBehaviour
{
    // Dichiariamo la firma del delegato (il tipo)
    // public delegate void Azione();

    // Creiamo la variabile (l'istanza) a cui gli altri si iscriveranno
    public event Action OnPulsantePremuto;

    void Start()
    {
        OnPulsantePremuto += () =>
        {
            Debug.Log("Suono: Beep");
        };
    }

    void Update()
    {
        // Simuliamo la pressione fisica del tasto con la Barra Spaziatrice
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Telecomando: Ho premuto il tasto");

            // Eseguiamo (Inviamo il segnale)
            // L'operatore ? controlla se il delegato è nullo (cioè se non c'è nessuna funzione collegata) prima di provare a eseguirlo.
            OnPulsantePremuto?.Invoke();
        }
    }
}