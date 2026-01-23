using UnityEngine;

public class PlayerControllerAnimation : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private Camera mainCamera;
    private Transform neckTransform;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Limiti Rotazione Collo")]
    [SerializeField] private Vector3 neckRotationOffset = new Vector3(0f, 0f, 0f);
    [SerializeField] private float maxNeckAngle = 90f; // Limite umano (90° a DX e 90° a SX = 180° totali)

    private float verticalVelocity = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        // Attiva il peso del layer se necessario
        animator.SetLayerWeight(1, 1f);

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Neck")
            {
                neckTransform = child;
                break;
            }
        }
    }

    void Update()
    {
        // Movimento standard (come da tuo codice)
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Vertical", inputVertical);
        animator.SetFloat("Horizontal", inputHorizontal);

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movimento = (cameraForward * inputVertical + cameraRight * inputHorizontal).normalized;

        if (movimento.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 finalMove = movimento * moveSpeed;
        verticalVelocity += gravity * Time.deltaTime;
        finalMove.y = verticalVelocity;
        characterController.Move(finalMove * Time.deltaTime);

        if (characterController.isGrounded && verticalVelocity < 0) verticalVelocity = -2f;
    }

    void OnAnimatorIK(int layerIndex)
    {
        // Eseguiamo la logica solo sul layer con la maschera (Layer 1)
        if (layerIndex != 1) return;
        if (animator == null || !animator.isHuman || neckTransform == null) return;

        // 1. NUOVA LOGICA: Prendi la direzione in cui punta il mouse (Camera Forward)
        // Non calcoliamo più la distanza dalla camera, usiamo il suo orientamento
        Vector3 lookDirection = mainCamera.transform.forward;

        // Opzionale: azzeriamo la Y se vogliamo che la testa giri solo a destra/sinistra
        // Se vuoi che guardi anche in alto/basso, commenta la riga sotto
        lookDirection.y = 0f;
        lookDirection.Normalize();

        // 2. CALCOLA L'ANGOLO RELATIVO
        // Confrontiamo il petto del player (transform.forward) con la mira della camera
        float angleBetween = Vector3.SignedAngle(transform.forward, lookDirection, Vector3.up);

        // 3. APPLICA IL LIMITE UMANO (CLAMP)
        // Impedisce alla testa di girare oltre i gradi impostati (es. 90°)
        angleBetween = Mathf.Clamp(angleBetween, -maxNeckAngle, maxNeckAngle);

        // 4. CREA LA ROTAZIONE LOCALE
        // Ruotiamo l'osso Neck sull'asse verticale (Vector3.up) in base all'angolo limitato
        Quaternion localNeckRotation = Quaternion.AngleAxis(angleBetween, Vector3.up);

        // Applichiamo l'offset necessario per gli skeleton di Mixamo
        localNeckRotation *= Quaternion.Euler(neckRotationOffset);

        // 5. APPLICA ALL'ANIMATOR
        animator.SetBoneLocalRotation(HumanBodyBones.Neck, localNeckRotation);
    }
}