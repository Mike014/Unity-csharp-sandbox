using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

// 1. La classe/struct che vogliamo salvare
[System.Serializable]
public struct WeaponStats
{
    public string Name;
    public int Damage;
    public float FireRate;
}

public class Weapon : MonoBehaviour
{
    void Start()
    {
        // 2. Creiamo un'arma
        WeaponStats sword = new WeaponStats
        {
            Name = "Excalibur",
            Damage = 150,
            FireRate = 1.5f
        };

        // 3. Definiamo il percorso del file
        string path = Application.persistentDataPath + "/weapong.xml";

        // 4. SERIALIZZAZIONE: oggetto C# → file XML
        XmlSerializer serializer = new XmlSerializer(typeof(WeaponStats)); // "Traduci la classe Weapon"
        using (FileStream stream = new FileStream(path, FileMode.Create)) // Apri/crea il file
        {
            serializer.Serialize(stream, sword); // Scrivi l'oggetto nel file
        }

        Debug.Log("Salvato in: " + path);

        // 5. DESERIALIZZAZIONE: file XML → oggetto C#
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            WeaponStats loadedWeapon = (WeaponStats)serializer.Deserialize(stream);
            Debug.Log($"Caricata: {loadedWeapon.Name} | Danno: {loadedWeapon.Damage}");
        }
    }
}










