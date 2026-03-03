using UnityEngine;
using System;

public class DebugDelegateInstance : MonoBehaviour
{
    public DebugDelegate debug;

    void Awake()
    {
        debug = Print;
    }

    void Start()
    {
        debug("Questo è un delegato");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }
}