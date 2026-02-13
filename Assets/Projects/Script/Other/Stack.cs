using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    readonly Stack<string> nameStack = new Stack<string>();

    void Start()
    {
        Debug.Log("Start...");

        // Aggiungi 5 nomi allo stack
        for (int i = 0; i < 5; i++)
        {
            nameStack.Push($"Nome_{i}");
        }

        Debug.Log($"Stack contiene {nameStack.Count} elementi");
    }
}
