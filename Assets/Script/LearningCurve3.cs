using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve3 : MonoBehaviour
{
    public bool hasDungeonKey = false;
    public string weaponType = "Arcane Staff";

    void Start()
    {
        if(!hasDungeonKey)
        {
            Debug.Log("You may not enter without the sacred key.");
        }
        else
        {
            Debug.Log("You can come in.");
        }

        if(weaponType != "Longsword")
        {
            Debug.Log("You don't appear to have the right type of weapon..");
        }
    }
}
