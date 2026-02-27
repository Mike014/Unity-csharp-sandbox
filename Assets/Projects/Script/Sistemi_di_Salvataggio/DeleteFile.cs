using UnityEngine;
using System.IO;
using System;

public class DeleteFile : MonoBehaviour
{
    private string _dataPath;
    private string _textFile;

    void Awake()
    {
        // Definiamo la cartella e il percorso del file
        _dataPath = Application.persistentDataPath + "/Player_Data";
        _textFile = _dataPath + "Save_Data.txt";
    }

    void Start()
    {
        Debug.Log($"Il percorso si trova in : {_dataPath}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NewTextFile();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateTextFile();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadFromFile(_textFile);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeletedFile(_textFile);
        }
    }

    /*
    Il metodo verifica se il file esiste già per evitare sovrascritture accidentali. Usa File.WriteAllText, che crea il file, scrive il contenuto e lo chiude immediatamente.
    */
    public void NewTextFile()
    {
        if (File.Exists(_textFile))
        {
            Debug.Log("File already exists...");
            return;
        }
        // Crea il file e scrive una nuova riga (\n)
        File.WriteAllText(_textFile, "\n");
        Debug.Log("New File created");
    }

    /*
    Per aggiungere dati (come il timestamp di inizio sessione) senza cancellare il contenuto precedente, si usa AppendAllText.
    */
    public void UpdateTextFile()
    {
        if (!File.Exists(_textFile))
        {
            Debug.Log("File doesn't exist...");
            return;
        }
        // Aggiunge testo alla fine del file esistente
        File.AppendAllText(_textFile, $"Game started: {DateTime.Now}\n");
        Debug.Log("File updated successfully!");
    }

    /*
    Recupera l'intero contenuto del file sotto forma di stringa per visualizzarlo o elaborarlo.
    */
    public void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist...");
            return;
        }
        // Legge tutto e stampa in console
        Debug.Log(File.ReadAllText(filename));
    }

    /*
    Elimina il file dal disco dopo aver verificato che esista effettivamente.
    */
    public void DeletedFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist or has already been deleted...");
            return;
        }
        File.Delete(filename);
        Debug.Log("File successfully deleted!");
    }
}
