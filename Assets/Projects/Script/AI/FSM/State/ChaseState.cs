using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    [Header("Configurazione")]
    public float chaseSpeed = 6.0f; // Corre più veloce quando insegue!
    public string playerTag = "Player";

    private NavMeshAgent agent;
    private Transform playerTransform;

    public override void StateEnter()
    {
        agent = controller.GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    public override void StateUpdate()
    {
        if (playerTransform != null)
        {
            // Aggiorniamo la destinazione ogni frame perché il player si muove
            agent.SetDestination(playerTransform.position);
        }
    }

    public override void StateExit()
    {
        if(agent != null)
        {
            agent.ResetPath();
        }
    }
}