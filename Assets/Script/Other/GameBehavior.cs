using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    // DATI PRIVATI (Backing Variables)
    // Questi sono i dati reali, nascosti al mondo esterno.
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // Variabili per le regole di gioco PUBBLICHE
    public int maxItems = 4;

    // Riferimenti agli oggetti UI 
    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;

    void Start()
    {
        // Inizializza: All'avvio scriviamo i valori di default
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;
    }


    // 1. PROPRIETÀ PUBBLICA per gli Oggetti
    // Notare che non ha parentesi () come un metodo, ma ha { get; set; }
    public int Items
    {
        // GET (Lettura): Chiunque chieda "Quanti oggetti ho?", riceve il valore di _itemsCollected.
        get { return _itemsCollected; }

        // SET (Scrittura): Chiunque scriva "Items = 5", attiva questo blocco.
        set
        {
            // 'value' è una parola chiave magica che contiene il nuovo numero inviato (es. 5)
            _itemsCollected = value;

            itemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= maxItems)
            {
                progressText.text = "You've found all the items!";
                // Qui potresti anche aggiungere: Time.timeScale = 0; per mettere in pausa
                Time.timeScale = 0;
            }
            else
            {
                progressText.text = "Item found, only " + (maxItems - _itemsCollected) + " more!";


                //    // Possiamo aggiungere logica extra! Qui stampiamo un log ogni volta che il valore cambia.
                //    Debug.LogFormat("Items: {0}", _itemsCollected);
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            // Debug.LogFormat("Lives: {0}", _itemsCollected);

            // Aggiornamento salute
            healthText.text = "Player Health: " + HP;
        }
    }
}
