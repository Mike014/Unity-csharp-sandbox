using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Necessario per utilizzare UnityEvent

public class Test_UnityEvents2 : MonoBehaviour
{
    [SerializeField] UnityEvent<int> m_MyEvent;

    public void DoSomething(int i) // Il listener deve avere la stessa firma, ovvero in questo caso un parametro int, come l'unity event istanziato
    {
        Debug.Log("Callback Executed :" + i);
    }

    void Start()
    {
        if(m_MyEvent == null)
           m_MyEvent = new UnityEvent<int>();

        m_MyEvent.AddListener(DoSomething); /*AddListener: Questo è l'equivalente via codice del trascinare una funzione nell'Inspector. 
        Stai dicendo: "Ehi evento, quando scatti, ricordati di chiamare anche la funzione OnEventTriggered".*/
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke(5);
        }
    }
}

//  Gli unity event sono sempliocemente degli eventi che hanno associato una funzione, le callback
//  A questi possono essere associati dei parametri
