using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
    // 1. Viene chiamato quando un oggetto ENTRA nel trigger
    void OnTriggerEnter(Collider other)
    {
        // 2. Verifichiamo se l'oggetto che è entrato si chiama "Player"
        if(other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }

    // 3. Viene chiamato quando un oggetto ESCE dal trigger
    void OnTriggerExit(Collider other)
    {
        // 4. Verifichiamo se l'oggetto che è uscito è il Player
        if(other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}