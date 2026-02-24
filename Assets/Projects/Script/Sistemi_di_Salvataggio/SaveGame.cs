using System;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private string _path => Application.persistentDataPath + "/savefile.json";

    public void Save(SaveData data)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(_path, json);
            Debug.Log("Salvataggio completato in: " + _path);
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nel salvataggio: {e.Message}");
        }
    }
    public SaveData Load()
    {
        if (!File.Exists(_path))
        {
            Debug.LogWarning("File di salvataggio non trovato!");
            return null;
        }

        try
        {
            string json = File.ReadAllText(_path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Caricamento completato da: " + _path);
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nel caricamento: {e.Message}");
            return null;
        }
    }

    public void Delete()
    {
        if (!File.Exists(_path))
        {
            Debug.LogWarning("File di salvataggio non trovato!");
            return;
        }

        try
        {
            File.Delete(_path);
            Debug.Log("File eliminato: " + _path);
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nella cancellazione: {e.Message}");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData data = new SaveData();
            data.score = 150;
            data.name = "Player";
            Save(data);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveData data = Load();
            if (data != null)
                Debug.Log($"Score: {data.score} | Nome: {data.name}");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Delete();
        }
    }
}