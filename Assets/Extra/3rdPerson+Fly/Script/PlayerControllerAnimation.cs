using UnityEngine;

public class PlayerControllerAnimation : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private Camera mainCamera;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;
    
    // Variabili per lo smoothing del movimento fisico
    [SerializeField] private float movementSmoothTime = 0.15f; 
    private Vector3 currentMoveVelocity;
    private Vector3 currentMoveDir; // Direzione attuale smussata

    [Header("Head Look Settings")]
    [SerializeField] private float lookWeight = 1f;
    [SerializeField] private float bodyWeight = 0.3f; // Quanto il corpo aiuta la testa
    [SerializeField] private float headWeight = 1f;
    [SerializeField] private float clampWeight = 0.5f;
    [SerializeField] private float lookDistance = 20f; // Quanto lontano guarda

    private float verticalVelocity = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        // Abilita il layer IK se presente (assicurati che il layer 1 sia per l'IK o upper body)
        // Se usi solo un layer base, questo non serve o va messo a 0.
        // animator.SetLayerWeight(1, 1f); 
    }

    void Update()
    {
        // 1. INPUT
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        // 2. ANIMAZIONE FLUIDA (Best Practice)
        // Invece di passare inputVertical grezzo, usiamo il dampTime (0.1f)
        // Questo fa sì che l'animatore interpoli i valori nel tempo.
        animator.SetFloat("Vertical", inputVertical, 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal", inputHorizontal, 0.1f, Time.deltaTime);

        // 3. CALCOLO DIREZIONE CAMERA
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 targetDirection = (cameraForward * inputVertical + cameraRight * inputHorizontal).normalized;

        // 4. MOVIMENTO FISICO FLUIDO (SmoothDamp)
        // Invece di applicare subito targetDirection, interpoliamo verso di essa.
        // Questo crea inerzia: il personaggio non parte e si ferma all'istante.
        currentMoveDir = Vector3.SmoothDamp(currentMoveDir, targetDirection, ref currentMoveVelocity, movementSmoothTime);

        // 5. ROTAZIONE DEL CORPO
        // Ruotiamo solo se c'è un input significativo, ma usiamo la direzione target per la rotazione
        if (targetDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 6. APPLICAZIONE MOVIMENTO
        // Usiamo currentMoveDir (la versione smussata) per muoverci
        Vector3 finalMove = currentMoveDir * moveSpeed;
        
        // Gravità
        if (characterController.isGrounded && verticalVelocity < 0) verticalVelocity = -2f;
        verticalVelocity += gravity * Time.deltaTime;
        finalMove.y = verticalVelocity;

        characterController.Move(finalMove * Time.deltaTime);
    }

    // Usiamo OnAnimatorIK per gestire lo sguardo in modo nativo Unity
    void OnAnimatorIK(int layerIndex)
    {
        if (animator == null) return;

        // Definiamo dove guardare. 
        // Se è un TPS, "dove punta il mouse" significa "un punto lungo il forward della camera".
        Vector3 lookAtTarget = mainCamera.transform.position + (mainCamera.transform.forward * lookDistance);

        // Impostiamo il target dello sguardo
        animator.SetLookAtPosition(lookAtTarget);

        // Impostiamo i pesi (quanto intensamente guardare)
        // weight globale, body, head, eyes, clamp (0-1)
        animator.SetLookAtWeight(lookWeight, bodyWeight, headWeight, 1f, clampWeight);
    }
}