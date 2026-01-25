using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Se viene premuto il tasto sinistro del mouse (0)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;

            // Lancia un raggio dalla telecamera verso la posizione del mouse sullo schermo
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
            {
                _agent.destination = _hit.point;
            }
        }
    }
}
