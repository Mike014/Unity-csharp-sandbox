using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve5 : MonoBehaviour
{
    // Lista vuota
    // List<string> QuestPartyMembers = new List<string>();

    // Lista con valori iniziali
    List<string> QuestPartyMembers = new List<string>()
    {
        "Mickey Mouse",
        "Bugs Bunny",
        "Sterling the Knight"
    };

    void Start()
    {
        for (int i = 0; i < QuestPartyMembers.Count; i++)
        {
            Debug.Log(QuestPartyMembers[i]);
        }
    }
}