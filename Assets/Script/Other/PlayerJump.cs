using UnityEngine;

public class DoubleJumpController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 150f;
    
    private bool jumpRequested = false;
    private int remainingJumps = 2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if(jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce);
            remainingJumps--;
            jumpRequested = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            remainingJumps = 2;  
        }
    }
}