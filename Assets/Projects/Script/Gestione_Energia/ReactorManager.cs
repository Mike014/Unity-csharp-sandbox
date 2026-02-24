using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReactorManager : MonoBehaviour
{
    // 1. Variabile statica privata (nascosta nello Heap, accessibile solo alla classe)
    private static ReactorManager _instance;
    // Flag per evitare il problema del "Fantasma" in chiusura
    private static bool _isQuitting = false;
    private int _energy = 100;
    public static event Action<int> OnEnergyChanged;

    // Property pubblica
    public static ReactorManager Instance
    {
        get
        {
            if (_isQuitting)
            {
                Debug.Log("Il gioco sta chiudendo, non ricreo il Singleton!");
                return null;
            }

            if (_instance == null)
            {
                // Cerca nella scena
                _instance = FindAnyObjectByType<ReactorManager>();

                // Se non c'è, crealo da zero (Lazy Instantiation)...
                if (_instance == null)
                {
                    GameObject container = new GameObject("ReactorManager");
                    _instance = container.AddComponent<ReactorManager>();
                }
            }
            return _instance;
        }
    }

    public void ModifyEnergy(int amount)
    {
        _energy += amount;

        // Controlla se l'oggetto è Null
        OnEnergyChanged?.Invoke(_energy);
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
