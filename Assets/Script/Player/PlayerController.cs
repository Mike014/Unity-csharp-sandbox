using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    // Velocità impostabile nell'Inspector
    public float moveSpeed = 5f; 
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Leggi input WASD
        float horizontal = Input.GetAxis("Horizontal"); // A/D o Frecce sinistra/destra
        float vertical = Input.GetAxis("Vertical");     // W/S o Frecce su/giu

        // Crea la direzione di movimento
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    void FixedUpdate()
    {
        // ⚠️ PERCHÉ FixedUpdate? Perché RigidBody funziona in sync con la physics engine
        // Applica il movimento tramite RigidBody
        rb.velocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.velocity.y,              // Preserva la gravità Y
            moveDirection.z * moveSpeed
        );
    }
}

// Update() per l'input (più responsivo)
// FixedUpdate() per RigidBody (sincronizzato con la physics)
// .normalized per evitare movimento diagonale più veloce