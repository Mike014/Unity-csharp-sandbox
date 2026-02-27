using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/*
Prima di tutto, devi "autorizzare" il tuo oggetto a essere serializzato aggiungendo l'attributo [Serializable].
*/
[Serializable]
public struct XMLWeapon
{
    public string name;
    public int damage;

    // Costruttore
    public XMLWeapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
}

public class SerializeXML : MonoBehaviour
{
    private string _xmlWeapons;
    private string _dataPath;
    private string _state;

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data";
        _xmlWeapons = _dataPath + "WeaponInventory.xml";
    }

    private List<XMLWeapon> weaponInventory = new List<XMLWeapon>
    {
        new XMLWeapon("Sword of Doom", 100),
        new XMLWeapon("Butterfly knives", 25),
        new XMLWeapon("Brass Knuckels", 15),
    };

    public void MySerializeXML()
    {
        var xmlSerializer = new XmlSerializer(typeof(List<Weapon>));

        using (FileStream stream = File.Create(_xmlWeapons))
        {
            xmlSerializer.Serialize(stream, weaponInventory);
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
        _state = "Initialized...";
        Debug.Log(_state);

        FileUtilities.LogDirectoryInfo(Application.persistentDataPath);
        NewDirectory();
        MySerializeXML();
    }
}
