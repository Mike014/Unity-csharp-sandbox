using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour 
{
    // 1. Questo metodo viene chiamato AUTOMATICAMENTE da Unity quando avviene un urto fisico
    void OnCollisionEnter(Collision collision)
    {
        // 2. Controlliamo CHI ci è venuto addosso
        // La variabile 'collision' contiene le info sull'altro oggetto
        if(collision.gameObject.name == "Player")
        {
            // 3. Rimuove l'oggetto (questo script è attaccato alla pozione) dalla scena
            Destroy(this.transform.gameObject);
            
            // 4. Messaggio di debug in console
            Debug.Log("Item collected!");
        }
    }
}