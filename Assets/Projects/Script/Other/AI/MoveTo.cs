using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        NavMeshAgent _agent = GetComponent<NavMeshAgent>();
        if(_agent == null)
        {
            Debug.Log("NavMeshAgent Missing");
        }
        else
        {
            Debug.Log("NavMeshAgent Found!");
        }
        _agent.destination = goal.position;
    }
}
