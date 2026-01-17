using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Quanto tempo vive un proiettile? 
    public float onScreenDelay = 3f;

    void Start()
    {
        /**
        Programmiamo l'autodistruzione nel momento stesso in cui l'oggetto nasce
        Destroy accetta due parametri: CHI distruggere e DOPO QUANTO tempo.
        **/
        Destroy(this.gameObject, onScreenDelay);
    }

}

