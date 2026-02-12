using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    // Il Transform dell'oggetto "Padre" che contiene tutti i punti di pattuglia
    // Il componente Transform contiene position e rotation. 
    // Se avessimo salvato i GameObject avremmo docuto chiamare .transform ogni volta che volevamo muovere il nemico
    // sprecando cicli di CPU
    public Transform patrolRoute;

    // Lista dinamica che conterrà i riferimenti ai singoli punti (Waypoints)
    public List<Transform> locations;

    // Variavile pubblica per memorizzare il riferimento al Player
    public Transform player;

    // Variabili private per lo stato interno
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private GameBehaviour _gameManager;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private int _lives = 3;

    // Start viene eseguito una sola volta all'avvio del gioco o all'attivazione dell'oggetto
    void Start()
    {
        // Prendiamo i riferimenti al capsule e a rigidbody
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

        // Otteniamo il riferimento al componente NavMeshAgent
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null) return;

        // Troviamo il Player automaticamente all'avvio della scena
        // Cerca nella gerarchia un oggeto che si chiama esettamente Player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();

        // Prepariamo i dati necessari prima che il nemico inizi a muoversi
        InitializePatrolRoute();

        // NuovoMetodo MoveToNextPatrolLocation();
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            // Nuovo metodo
            MoveToNextPatrolLocation();
        }
    }

    void Update()
    {
        // Controllo continuo: Siamo arrivati??
        // Controlliamo se la distanza rimanente è minima (< 0.2)
        // E se Unity ha finito di calcolare il percorso (!pathPending)
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    // Metodo personalizzato per riempire la lista delle posizioni in modo automatico
    void InitializePatrolRoute()
    {
        // Assicuriamoci che la lista sia inizializzata per evitare errori
        locations = new List<Transform>();

        if (patrolRoute != null)
        {
            // Cicliamo attraverso ogni oggetto "figlio" contenuto nel Transform patrolRoute
            // In Unity, iterare su un Transform significa scorrere i suoi figli nella Hierarchy
            foreach (Transform child in patrolRoute)
            {
                // Aggiungiamo il riferimento del figlio alla nostra lista "locations"
                locations.Add(child);
            }
        }
    }

    void MoveToNextPatrolLocation()
    {
        // Defensive Programming: se la lista è vuota, non fare nulla
        if (locations.Count == 0) return;

        // Impostiamo la destinazione dell'agente
        _agent.destination = locations[_locationIndex].position;

        // Operatore modulo per il ciclo infinto
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    // Viene chiamato automaticamente da Unity quando un altro Collider entra nel raggio del Trigger
    // Nota: Il GameObject deve avere un Collider con "Is Trigger" attivato
    void OnTriggerEnter(Collider other)
    {
        // Controlliamo se il nome dell'oggetto che è entrato è esattamente "Player"
        // 'other' rappresenta il corpo che ha attraversato il confine del trigger
        if (other.name == "Player")
        {
            // Se è il giocatore, stampiamo un messaggio nella Console di Unity
            Debug.Log("Player detected - attack!");

            // Il nemico va verso il giocatore
            _agent.destination = player.position;
        }
    }

    // Viene chiamato automaticamente quando un oggetto che era dentro il Trigger ne esce
    void OnTriggerExit(Collider other)
    {
        // Verifichiamo se l'oggetto che sta uscendo è il Player
        if (other.name == "Player")
        {
            // Se il giocatore si allontana, il nemico smette di "vederlo"
            Debug.Log("Player out of range, resume patrol");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se l'oggetto che ci ha toccato si chiama "Enemy"...
        if (collision.gameObject.name == "Enemy")
        {
            // ...riduciamo la vita globale tramite il manager
            _gameManager.HP -= 1;
        }

        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1; // Questo attiva il 'set' privato qui sopra
            Debug.Log("Critical hit!");
        }
    }

    public int EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;

            // Logica reattiva: Controllo la morte nel momento stesso in cui la vita cambia
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }
}