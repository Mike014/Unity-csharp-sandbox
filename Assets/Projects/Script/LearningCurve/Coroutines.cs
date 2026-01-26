using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    public int a = 5;

    IEnumerator MyCoroutine()
    {
        while (true)
        { 
            int _a = a;
            Debug.Log(_a);
            yield return null;  // comando che interrompe temporaneamente l'esecuzione
                                // Il valore dopo yield return indica quanto tempo aspettare prima di riprendere
                                // null significa "riprendi al prossimo frame"
                                // Pausa di 1 Frame
            _a += 2;    
            Debug.Log(_a);
            yield return new WaitForSeconds(5); // Pausa di 5 Frame
            if (a == 5)
            {
                StopCoroutine(MyCoroutine());
                Debug.Log("Coroutine Stopped!!!");
            }
        }
    }

    void Start()
    {
        StartCoroutine(MyCoroutine());
        // a = Random.Range(1,100);
        a = 1;
    }

    void Update()
    {
        a = Random.Range(1, 10);
    }
}

/*
Pattern dell'Output

L'output seguirà questo pattern ciclico (ogni 2 frame):
```
Frame 1:  5        ← Valore iniziale
Frame 2:  7        ← 5 + 2
Frame 3:  [random] ← Nuovo valore da Update
Frame 4:  [random + 2]
Frame 5:  [random] ← Nuovo valore da Update
Frame 6:  [random + 2]
*/