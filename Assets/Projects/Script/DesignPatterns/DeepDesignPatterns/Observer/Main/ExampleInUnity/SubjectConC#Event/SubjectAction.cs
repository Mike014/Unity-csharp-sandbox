using UnityEngine;
using System;

public class SubjectAction : MonoBehaviour
{
    public event Action<string, GameEvent> OnEntityEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnEntityEvent?.Invoke("Hero", GameEvent.EntityFell); // utilizzo una stringa e un enum all'interno di GameEvent
        }
    }
}


// Subject con C# event