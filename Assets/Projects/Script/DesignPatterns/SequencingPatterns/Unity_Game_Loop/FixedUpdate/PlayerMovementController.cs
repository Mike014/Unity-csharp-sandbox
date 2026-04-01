using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private int _remainingJumps = 2;
    private Vector3 _moveDirection;
    private bool _isGrounded;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Crea la direzione di movimento
        _moveDirection = Vector3.forward;

        if (Input.GetKeyDown(KeyCode.Space) && _remainingJumps > 0)
        {
            Jump();
            _remainingJumps--;
        }
    }

    void FixedUpdate()
    {
        // 1. Calcola la posizione target per questo frame
        Vector3 targetPosition = _rb.position + (_moveDirection * _speed * Time.fixedDeltaTime);

        // 2. Chiedi al physics engine di muoversi verso quella posizione
        _rb.MovePosition(targetPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
        _remainingJumps = 2;
    }

    void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    void Jump()
    {
        // AddForce(force, ForceMode.Force);
        _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
    }
}



