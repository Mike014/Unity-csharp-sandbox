using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    [SerializeField]
    float currentAge = 35f;

    void Start()
    {
        // Debug.Log("My age is: " + CurrentAge);
    }

    void Update()
    {
        // CurrentAge++;
        // Debug.Log("My age for frame are: " + CurrentAge);
        currentAge += Time.deltaTime;
        Debug.Log("My simulated age is: " + currentAge);
    }

    void ComputeAge()
    {
        Debug.Log("My age is: " + currentAge);
    }
}
