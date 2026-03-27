using UnityEngine;

public class PhysicsSystem : Subject
{
    private void Update()
    {
        // simula : premi Space = entità cade
        if (Input.GetKeyDown(KeyCode.Space))
            Notify("Hero", GameEvent.EntityFell);
    }
}