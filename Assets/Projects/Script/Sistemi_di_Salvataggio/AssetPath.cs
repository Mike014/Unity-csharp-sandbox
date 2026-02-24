using System;
using System.IO;
using UnityEngine;

public class AssetPath : MonoBehaviour
{
    // 1. Dichiariamo solo le variabili all'inizio, senza assegnare valori dipendenti da Unity
    private string _saveFolder;
    private string _filePath;

    void Awake()
    {
        try
        {
            
            // 2. Awake è il primo evento ufficiale di Unity. Ora le API sono pronte!
            _saveFolder = Path.Combine(Application.persistentDataPath, "Saves");

            // 3. Ora che _saveFolder esiste, possiamo calcolare _filePath
            _filePath = Path.Combine(_saveFolder, "savefile.json");

            NewDirectory();

            Debug.Log("Il percorso calcolato è: " + _filePath);
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nella creazione della cartella: {e.Message}");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteDirectory();
        }
    }

    public void NewDirectory()
    {
        // 1. Controlla se il percorso esiste già
        if (Directory.Exists(_saveFolder))
        {
            // 2. Se esiste, esce dal metodo
            Debug.Log("Directory already exists...");
            return;
        }

        // 3. Se non esiste, crea la nuova cartella
        Directory.CreateDirectory(_saveFolder);
        Debug.Log("New directory created!");
    }

    public void DeleteDirectory()
    {
        // 1. Verifica che la directory esista effettivamente
        if (!Directory.Exists(_saveFolder))
        {
            // 2. Se non esiste, non c'è nulla da cancellare
            Debug.Log("Directory doesn't exist or has already been deleted...");
            return;
        }

        // 3. Elimina la cartella e tutti i file contenuti (recursive: true)
        Directory.Delete(_saveFolder, true);
        Debug.Log("Directory successfully deleted!");
    }
}



