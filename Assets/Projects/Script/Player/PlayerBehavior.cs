using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Variabili pubbliche per configurare la velocità dall'Inspector
    public float moveSpeed = 5f;
    public float rotateSpeed = 75f;

    // Variabili private per memorizzare l'input del giocatore
    private float _vInput;
    private float _hInput;

    // Variabili per il salto
    public float jumpVelocity = 5f;
    private bool _isJumping;

    // Variabili per il controllo del LayerMask
    public float distanceToGround = 0.1f;
    // Selettore nell'Inspector per decidere cosa è "Terra"
    public LayerMask GroundLayer;
    // Riferimento al Collider del player (per sapere quanto è alto)
    private CapsuleCollider _col;
    
    // Variabile per conservare il riferimento al RigidBody
    private Rigidbody _rb;

    // Variabili per lo shooting
    // Riferimento al prefab
    public GameObject bullet;
    public float bulletSpeed = 100f;
    private bool _isShooting;

    void Start()
    {
        // Recuperiamo il componente Rigidbody collegato a questo oggetto
        _rb = GetComponent<Rigidbody>();
        // Recuperiamo il collider della capsula
        _col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        // Rileva input W/S o Frecce Su/Giù
        _vInput = Input.GetAxis("Vertical") * moveSpeed;

        // Rileva input A/D o Frecce Sinistra/Destra    
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // Rilevamento Input (J per saltare)
        /* Usiamo l'operatore |= (OR Assegnazione) per non perdere il click.
           KeyCode.Space è una Enum che corrisponde al tasto fisico 'Space'.*/
        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        // Input di sparo
        // Usiamo |= per non perdere il frame dell'input
        _isShooting |= Input.GetKeyDown(KeyCode.Mouse0);

        // PRIMA VERSIONE DI MOVIMENTO PLAYER CON TRANSFORM
        // // Muove la capsula avanti/indietro
        // this.transform.Translate(Vector3.forward *_vInput * Time.deltaTime);
        // // Ruota la capsula attorno all'asse Y (su se stessa)
        // this.transform.Rotate(Vector3.up *_hInput * Time.deltaTime);
    }

    // La fisicia deve sempre stare in FixedUpdate
    void FixedUpdate()
    {
        // Calcola la rotazione
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // Applicazione del movimento fisico
        // Spostiamo il Rigidbody alla posizione attuale + il passo in avanti calcolato
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        // Applicazione della rotazione fisica
        _rb.MoveRotation(_rb.rotation * angleRot);
         
        // Esecuzione fisica
        if(IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        // Reset del flag
        _isJumping = false;

        // Logica di sparo
        if(_isShooting)
        {
            // CREAZIONE (Instantiate)
            // Crea una copia del Prefab 'Bullet'.
            // Posizione: Davanti al player (+1 sull'asse Z) per non colpirsi da soli.
            // Rotazione: La stessa del player.
            GameObject newBullet = Instantiate(bullet,
                   this.transform.position + new Vector3(0, 0, 1),
                   this.transform.rotation);

            // Recupero Componente
            //Prendiamo il RigidBody della NUOVA copia appena creata
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            // Spinta (Velocity)
            // Impostiamo la velocità in avanti
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }

        _isShooting = false;

        /*
        In Update usavamo Time.deltaTime. 
        In FixedUpdate dobbiamo usare Time.fixedDeltaTime. È l'intervallo di tempo costante tra un calcolo fisico e l'altro. 
        Garantisce che la velocità di gioco sia identica su tutti i computer.
        */
    }

    private bool IsGrounded()
    {
        // Calcoliamo il punto più basso della capsula (i piedi)
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        // Chiediamo alla Fisica: "C'è qualcosa del Layer 'Ground' qui sotto?"
        bool grounded = Physics.CheckCapsule(
            _col.bounds.center,   // Inizio capsula (centro)
            capsuleBottom,        // Fine capsula (piedi)
            distanceToGround,     // Raggio (spessore del controllo)
            GroundLayer,          // Maschera (cosa cercare)
            QueryTriggerInteraction.Ignore // Ignora i Trigger (non si salta sull'aria)
        );

        return grounded;
    }
}
