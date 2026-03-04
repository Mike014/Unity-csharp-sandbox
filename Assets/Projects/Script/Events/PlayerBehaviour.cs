using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Definisce la firma: void, nessun parametro
    public delegate void JumpingEvent();

    // Crea gli eventi di quel tipo
    public event JumpingEvent OnPlayerJump;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerJump?.Invoke();
            Debug.Log("Evento sparato");
        }
    }
}
