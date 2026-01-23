using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiArray : MonoBehaviour
{
    int[,] Coordinates = new int[3, 2]
    {
        {5, 4},
        {1, 7},
        {9, 3}
    };

    void Start()
    {
        for (int i = 0; i < Coordinates.GetLength(0); i++)
        {
            for (int j = 0; j < Coordinates.GetLength(1); j++) 
            {
                int valore = Coordinates[i, j];
                Debug.Log("Coordinates[" + i + ", " + j + "] = " + valore);
            }
        }
    }
}
