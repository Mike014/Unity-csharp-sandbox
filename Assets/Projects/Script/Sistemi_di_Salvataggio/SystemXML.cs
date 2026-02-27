using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;

public class SystemXML : MonoBehaviour
{
    private string _dataPath;
    private string _xmlLevelProgress;
    private string _xmlStream;

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data";
        _xmlLevelProgress = _dataPath + "Progress_Data.xml";
    }

    void Start()
    {
        Debug.Log($"The Path is : {_dataPath}");
        Initialize();
    }

    public void WriteToXML(string fileName)
    {
        // Controlla che il file non esiste già
        if (!File.Exists(fileName))
        {
            // Crea il flusso fisico
            FileStream xmlStream = File.Create(fileName);

            // Crea il writer associato al flusso fisico
            XmlWriter xmlWriter = XmlWriter.Create(_xmlStream);

            // Inizia il documento XML
            xmlWriter.WriteStartDocument();

            // Apre il tag radice <level_progress>
            xmlWriter.WriteStartElement("level_progress");

            // Aggiunge 4 elementi <level> figli
            for (int i = 1; i < 5; i++)
            {
                xmlWriter.WriteElementString("level", "level-" + i);
            }

            // Chiude il tag radice </level_progress>
            xmlWriter.WriteEndElement();

            xmlStream.Close();
            xmlWriter.Close();
        }
    }

    public void WriteToXMLSafe(string fileName)
    {
        if(!File.Exists(fileName))
        {
            using (FileStream xmlStream = File.Create(fileName))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(xmlStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("level_progress");
                    xmlWriter.WriteEndElement();

                    // Entrambi si chiuderanno da soli qui
                }
            }
        }
    }

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

    public void Delete(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Debug.Log("File doesn't exist or has already been deleted...");
            return;
        }
        File.Delete(fileName);
        Debug.Log("File successfully deleted!");
    }

    private IEnumerator MyXMLCoroutine()
    {
        Debug.Log("Inizio");

        WriteToXML(_xmlLevelProgress); 
        yield return new WaitForSeconds(3f);
        Debug.Log("WriteToXML");

        ReadFromStream(_xmlLevelProgress);
        yield return new WaitForSeconds(3f);
        Debug.Log("ReadFromStream");

        Delete(_xmlLevelProgress);
        yield return new WaitForSeconds(3f);
        Debug.Log("Delete");
    }

    public void Initialize()
    {
        string _state = "SystemXML initialized...";
        Debug.Log(_state);

        // Chiamata al metodo di scrittura
        // WriteToXML(_xmlLevelProgress);

        // Per la lettura, si può usare il normale stream di testo
        // ReadFromStream(_xmlLevelProgress);

        StartCoroutine(MyXMLCoroutine());
    }
}


