using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Necessario per utilizzare UnityEvent

public class Test_UnityEvents : MonoBehaviour
{
    UnityEvent m_MyEvent;

    void OnEventTriggered()
    {
        Debug.Log("Callback Executed");
    }

    void Start()
    {
        if(m_MyEvent == null)
           m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(OnEventTriggered); /*AddListener: Questo è l'equivalente via codice del trascinare una funzione nell'Inspector. 
        Stai dicendo: "Ehi evento, quando scatti, ricordati di chiamare anche la funzione OnEventTriggered".*/
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }
    }
}

//  Gli unity event sono sempliocemente degli eventi che hanno associato una funzione, le callback
//  A questi possono essere associati dei parametri
