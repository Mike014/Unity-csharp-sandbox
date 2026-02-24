using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Variabile privata (nessuno la tocca da fuori)
    private static AudioManager _instance;

    // Proprietà pubblica (l'unica interfaccia col mondo)
    public static AudioManager Instance
    {
        get
        {
            // Controllo di sicurezza
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject("AudioManger");
                    _instance = go.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        Debug.Log("Musica di sottofondo in riproduzione!");
    }
}
