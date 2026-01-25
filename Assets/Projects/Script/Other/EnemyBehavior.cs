using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
    // Il Transform dell'oggetto "Padre" che contiene tutti i punti di pattuglia
    public Transform patrolRoute;

    // Lista dinamica che conterrà i riferimenti ai singoli punti (Waypoints)
    public List<Transform> locations;

    // Start viene eseguito una sola volta all'avvio del gioco o all'attivazione dell'oggetto
    void Start()
    {
        // Prepariamo i dati necessari prima che il nemico inizi a muoversi
        InitializePatrolRoute();
    }

    // Metodo personalizzato per riempire la lista delle posizioni in modo automatico
    void InitializePatrolRoute()
    {
        // Cicliamo attraverso ogni oggetto "figlio" contenuto nel Transform patrolRoute
        // In Unity, iterare su un Transform significa scorrere i suoi figli nella Hierarchy
        foreach(Transform child in patrolRoute)
        {
            // Aggiungiamo il riferimento del figlio alla nostra lista "locations"
            locations.Add(child);
        }
    }

    // Viene chiamato automaticamente da Unity quando un altro Collider entra nel raggio del Trigger
    // Nota: Il GameObject deve avere un Collider con "Is Trigger" attivato
    void OnTriggerEnter(Collider other)
    {
        // Controlliamo se il nome dell'oggetto che è entrato è esattamente "Player"
        // 'other' rappresenta il corpo che ha attraversato il confine del trigger
        if(other.name == "Player")
        {
            // Se è il giocatore, stampiamo un messaggio nella Console di Unity
            Debug.Log("Player detected - attack!");
        }
    }

    // Viene chiamato automaticamente quando un oggetto che era dentro il Trigger ne esce
    void OnTriggerExit(Collider other)
    {
        // Verifichiamo se l'oggetto che sta uscendo è il Player
        if(other.name == "Player")
        {
            // Se il giocatore si allontana, il nemico smette di "vederlo"
            Debug.Log("Player out of range, resume patrol");
        }
    }
}