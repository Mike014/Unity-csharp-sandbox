using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Qui stiamo utilizzando la tecnica CRUD (Creating, Reading, Updating and Deleting)
*/

public class MyStream : MonoBehaviour
{
    /*
    Si parte definendo il percorso del file. In questo esempio, l'autore aggiunge un nuovo file specifico per gli stream nell'Awake().
    */
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data";
        _textFile = _dataPath + "/Save_Data.txt";
        _streamingTextFile = _dataPath + "/Streaming_Save_Data.txt";

        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
            Debug.Log("Directory creata: " + _dataPath);
        }

    }

    void Start()
    {
        Initialize();
        Debug.Log(_dataPath);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            DeletedFile(_streamingTextFile);
            DeletedFile(_textFile);
        }
    }

    /*
    Questo metodo dimostra come scrivere e aggiungere dati. 
    Un dettaglio critico introdotto qui è la necessità assoluta di chiamare il metodo .Close() 
    dopo aver finito di usare lo stream, altrimenti il file rimane bloccato in memoria.
    */

    public void WriteToStream(string fileName)
    {
        // 1. Se il file non esiste, lo crea e inserisce un'intestazione
        if (!File.Exists(fileName))
        {
            StreamWriter newStream = File.CreateText(fileName);
            newStream.WriteLine("<Save Data> for Hero Born \n");
            newStream.Close(); // Chiudi il flusso
            Debug.Log("New file created with StreamWriter!");
        }

        // 2. A prescindere che esistesse già o sia stato appena creato,
        // apre il file in modalità Append (aggiunta) per non sovrascriverlo.
        StreamWriter streamWriter = File.AppendText(fileName);
        streamWriter.WriteLine("Game ended: " + DateTime.Now);
        streamWriter.Close();
        Debug.Log("File contents updated with StreamWriter!");
    }

    public void WriteToStramSafe(string fileName)
    {
        // Lo stream viene dichiarato tra parentesi dopo 'using'
        using (StreamWriter newStream = File.CreateText(fileName))
        {
            // Tutta la logica di scrittura va dentro le graffe
            newStream.WriteLine(" for HERO BORN \n");

            // Non serve chiamare newStream.Close() o Dispose()!
            // Succede automaticamente alla chiusura della graffa }
        }

        Debug.Log("File creato e stream chiuso automaticamente...");
    }

    /*
    La lettura segue la stessa logica protettiva (Look Before You Leap) che abbiamo visto in precedenza. 
    Usa l'istanza di StreamReader e chiama ReadToEnd() per scaricare tutto il testo in un colpo solo.
    */

    public void ReadFromStream(string fileName)
    {
        // 1. Esce se il file non esiste
        if (!File.Exists(fileName))
        {
            Debug.Log("File doesn't existe...");
            return;
        }

        // 2. Crea il lettore, legge tutto il file e lo stampa
        StreamReader streamReader = new StreamReader(fileName);
        Debug.Log(streamReader.ReadToEnd());
        streamReader.Close();
    }

    /*
    Tutti i metodi vengono richiamati in un punto centralizzato per l'inizializzazione del sistema:
    */

    public void Initialize()
    {
        string _state = "Data Manager Initialized...";
        Debug.Log(_state);

        StartCoroutine(StreamCoroutine());

        // WriteToStream(_streamingTextFile);
        // ReadFromStream(_streamingTextFile);
    }

    public void DeletedFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Debug.Log("File doesn't exist or has already been deleted...");
            return;
        }
        File.Delete(fileName);
        Debug.Log("File successfully deleted!");
    }

    private IEnumerator StreamCoroutine()
    {
        Debug.Log("Inizio");

        WriteToStream(_streamingTextFile);
        yield return new WaitForSeconds(3f);
        Debug.Log($"WriteToStream");

        WriteToStramSafe(_streamingTextFile);
        yield return new WaitForSeconds(3f);
        Debug.Log($"WriteToStreamSafe");

        ReadFromStream(_streamingTextFile);
        yield return new WaitForSeconds(3f);
        Debug.Log($"ReadFromStream");

        DeletedFile(_streamingTextFile);
        yield return new WaitForSeconds(3f);
        Debug.Log($"ReadFromStream");
    }
}




