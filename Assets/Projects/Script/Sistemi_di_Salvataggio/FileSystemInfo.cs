using System.IO;
using UnityEngine;

public static class FileUtilities
{
    /// <summary>
    /// Stampa informazioni dettagliate su una specifica directory nella console di Unity.
    /// </summary>
    /// <param name="path">Il percorso della cartella da analizzare.</param>
    public static void LogDirectoryInfo(string path)
    {
        // Usiamo DirectoryInfo per ottenere i metadati del percorso fornito
        DirectoryInfo dirInfo = new DirectoryInfo(path);

        Debug.Log("<color=cyan>--- FILE SYSTEM DEBUG ---</color>");
        Debug.LogFormat("<b>Percorso:</b> {0}", dirInfo.FullName);
        Debug.LogFormat("<b>Esiste:</b> {0}", dirInfo.Exists ? "<color=green>SÌ</color>" : "<color=red>NO</color>");
        
        if (dirInfo.Exists)
        {
            Debug.LogFormat("<b>Ultimo accesso:</b> {0}", dirInfo.LastAccessTime);
            // Possiamo anche contare quanti file ci sono dentro!
            Debug.LogFormat("<b>Numero di file:</b> {0}", dirInfo.GetFiles().Length);
        }
        Debug.Log("<color=cyan>-------------------------</color>");
    }
}