using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve7 : MonoBehaviour
{

    // Definiamo quali sono le opzioni possibili
    enum PlayerAction
    {
        Attack,
        Defend,
        Flee,
        Null
    };

    [SerializeField]
    PlayerAction currentAction;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentAction = PlayerAction.Attack;
            Debug.Log("Current Action : " + currentAction);
        }
        else if (Input.GetKey(KeyCode.Tab))
        {
            currentAction = PlayerAction.Defend;
            Debug.Log("Current Action : " + currentAction);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            currentAction = PlayerAction.Flee;
            Debug.Log("Current Action : " + currentAction);
        }
        else
        {
            Debug.Log("No Player Action");
        }

        Debug.Log("Mouse Posisition" + Input.mousePosition);
    }
}
