using UnityEngine;

public class refExample : MonoBehaviour
{
    int myHealth = 50;

    void ApplyHealing(ref int health)
    {
        // Il metodo legge il 50 e aggiunge 20
        health += 20;
    }

    void Start()
    {
        ApplyHealing(ref myHealth);
        Debug.Log("myHealth :"  +  myHealth);
        // Ora myHealth è 70
    }
}


