using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

using System.Text;

[Serializable]
public struct JSONWeapon
{
    public string name;
    public int damage;

    // Costruttore
    public JSONWeapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
}

public class SerializeJSON : MonoBehaviour
{
    private string _jsonWeapons;
    private string _dataPath;


    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/SerializeJSON_Data";
        _jsonWeapons = _dataPath + "WeaponJSON.json";
    }

    void Start()
    {
        Initialize();
    }

    public void MySerializeJSON()
    {
        JSONWeapon sword = new JSONWeapon("Sword of Doom", 100);
        string jsonString = JsonUtility.ToJson(sword, true);

        using (StreamWriter stream = File.CreateText(_jsonWeapons))
        {
            stream.WriteLine(jsonString);
        }
    }

    public void NewDirectory()
    {
        // 1. Controlla se il percorso esiste già
        if (Directory.Exists(_dataPath))
        {
            // 2. Se esiste, esce dal metodo
            Debug.Log("Directory already exists...");
            return;
        }
        // 3. Se non esiste, crea la nuova cartella
        Directory.CreateDirectory(_dataPath);
        Debug.Log("New directory created!");
    }

    public void Initialize()
    {
        string _state = "Initialized...";
        Debug.Log(_state);

        FileUtilities.LogDirectoryInfo(Application.persistentDataPath);
        NewDirectory();
        MySerializeJSON();
    }
}