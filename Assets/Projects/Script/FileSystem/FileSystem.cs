using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Aggiungiamo il namespace fondamentale per i file
using System.IO;

public class DataManager : MonoBehaviour
{
    private string _state;

    public void Initialize()
    {
        _state = "Data Manager initialized..";
        Debug.Log(_state);

        // 2. Chiamiamo il metodo che analizza il filesystem
        FilesystemInfo();
    }

    public void FilesystemInfo()
    {
        // 3. Estraiamo informazioni cruciali dal sistema
        
        // Il carattere usato per separare una lista di percorsi (es: ; su Windows, : su Mac)
        Debug.LogFormat("Path separator character: {0}", Path.PathSeparator);

        // IL PIÙ IMPORTANTE: Il carattere che separa le cartelle (es: \ su Windows, / su Mac)
        Debug.LogFormat("Directory separator character: {0}", Path.DirectorySeparatorChar);

        // La cartella esatta dove "vive" il tuo progetto Unity in questo momento
        Debug.LogFormat("Current directory: {0}", Directory.GetCurrentDirectory());

        // La posizione della cartella dei file temporanei del sistema operativo
        Debug.LogFormat("Temporary path: {0}", Path.GetTempPath());
    }
}