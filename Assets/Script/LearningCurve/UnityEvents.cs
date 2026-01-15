using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class UnityEvents : MonoBehaviour
{
    public UnityEvent test;
    private float floatTest;
    private AudioSource audioSource;
    public AudioClip bipSound;

    void Start()
    {
        floatTest = 0;

        audioSource = GetComponent<AudioSource>();

        // if(audioSource == null)
        // {
        //     Debug.Log("AudioSource non trovato! Aggiungi un componente AudioSource.");
        // }
        // else
        // {
        //     Debug.LogWarning("Bip sound non assegnato nell'Inspector!");
        // }
    }

    void Update()
    {
        floatTest += Time.deltaTime;

        if(floatTest >= 5)
        {
            test.Invoke();

            if(audioSource != null && bipSound != null)
            {
                audioSource.PlayOneShot(bipSound);
            }

            Debug.Log("Raggiunto 5! Bip suonato.");

            floatTest = 0;
        }
        else
        {
            Debug.Log("floatTest: " + floatTest);
        }
    }
}
