using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve6 : MonoBehaviour
{

    private AudioListener audioListener;

    void Start()
    {
        audioListener = GameObject.FindObjectOfType<AudioListener>();

        if(audioListener)
        {
            Debug.Log("It has Audio Listener");
        }
        else
        {
            Debug.Log("No Audio Listener");
        }
    }
}
