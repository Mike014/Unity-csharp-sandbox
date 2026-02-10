using System.Runtime.InteropServices.WindowsRuntime;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI; // Necessario per NavMeshAgent

public class WanderState : BaseState
{
    [Header("Configurazione")]
    public float wanderRadius = 10f;
    public float wanderSpeed = 1.5f;

    private NavMeshAgent agent;
    private Vector3 currentDestination;

    // Chiamato quando entriamo in questo stato
    public override void StateEnter()
    {
        // Recuperiamo l'agent del PADRE (dove sta il controller)
        agent = controller.GetComponent<NavMeshAgent>();

        agent.speed = wanderSpeed;
        SetRandomDestination();
    }

    // public override void StateExit() {}
    public override void StateUpdate()
    {
        // Se siamo arrivati a destinazione (o quasi), ne scegliamo una nuova
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        // STEP 1: Genera direzione casuale in una sfera
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        // ↑ insideUnitSphere = vettore casuale tra (-1,-1,-1) e (1,1,1)
        //   moltiplicato per wanderRadius = sfera con raggio 10

        // STEP 2: Sposta la sfera sulla posizione corrente del nemico
        randomDirection += controller.transform.position;
        // ↑ Ora randomDirection è un punto casuale in un raggio di 10m dal nemico
        Debug.Log("Random Direction : "+ randomDirection);

        NavMeshHit hit;

        // STEP 3: Trova il punto VALIDO più vicino sulla NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
        {
            // ↑ Se il punto casuale è fuori NavMesh, Unity trova il punto più vicino DENTRO

            currentDestination = hit.position;     // Salva destinazione
            agent.SetDestination(currentDestination); // Ordina all'agent di andarci
        }
    }
}

/*
I metodi di BaseState.cs devono essere "override" sovrascritti
*/