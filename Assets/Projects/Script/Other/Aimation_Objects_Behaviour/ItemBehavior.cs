using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour 
{
    // Creiamo una variabile del TIPO del nostro script manager
    // Non è un int o string, è proprio "GameBehavior"
    public GameBehaviour gameManager;

    void Start()
    {
        /*
        RICERCA AUTOMATICA
        Cercare nella scena un oggetto chiamato "Game Manager"e di estrarre il componente <GameBehavior> attaccato ad esso.
        */
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }
    // Questo metodo viene chiamato AUTOMATICAMENTE da Unity quando avviene un urto fisico
    void OnCollisionEnter(Collision collision)
    {
        // Controlliamo CHI ci è venuto addosso
        // La variabile 'collision' contiene le info sull'altro oggetto
        if(collision.gameObject.name == "Player")
        {
            // Rimuove l'oggetto (questo script è attaccato alla pozione) dalla scena
            Destroy(this.transform.gameObject);
            
            // Messaggio di debug in console
            Debug.Log("Item collected!");

            /*
            Usiamo la Property pubblica 'Items' del manager per incrementare il valore.
            Questo farà scattare automaticamente il Debug.Log che abbiamo messo nel 'set' del Manager.
            */
            gameManager.Items += 1;
            gameManager.PrintLootReport();
        }
    }
}