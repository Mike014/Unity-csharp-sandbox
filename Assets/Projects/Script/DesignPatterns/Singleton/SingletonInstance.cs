using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Chiama il Singleton...");
            SingletonGameManager.Instance.IncreaseScore(10);
        }
    }
}
