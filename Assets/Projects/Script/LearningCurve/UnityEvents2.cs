using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class UnityEvents2 : MonoBehaviour

{
    public UnityEvent<int> test;

    public int testOnInvoke()
    {
        Debug.Log("5 + 5 = " + 10);
        return 0;
    }

    void Start()
    {
        int result = testOnInvoke();
        test.Invoke(result);
    }
}
