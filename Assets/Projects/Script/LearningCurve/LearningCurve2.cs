using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve2 : MonoBehaviour
{
    public int currentGold;

    void Start()
    {
        currentGold = Random.Range(1, 101);

        Thievery();
    }

    public void Thievery()
    {
        if(currentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        }
        else if(currentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("Looks like your purse is in the sweet spot.");
        }
    }
}


// // Se passi INTERI → restituisce INT
// int risultato1 = Random.Range(1, 10);      // int tra 1 e 9

// // Se passi FLOAT → restituisce FLOAT
// float risultato2 = Random.Range(1.0f, 10.0f);  // float tra 1.0 e 10.0

// // Attenzione ai mix!
// float risultato3 = Random.Range(1, 10);    // int tra 1 e 9, poi convertito in float
