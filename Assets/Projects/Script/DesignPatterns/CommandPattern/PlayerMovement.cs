using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(Vector3 movement)
    {
        transform.Translate(movement);
    }
}

/*
The PlayerMovement script will contain a simple move function that applies a vector to our current
position.
*/