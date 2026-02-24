using UnityEngine;

/*
[System.Serializable] è un attributo C# che dice a Unity: "questa classe può essere convertita in dati salvabili e visibili nell'Inspector."
*/

[System.Serializable]
public class SaveData
{
    public int score;
    public string name;
    public Vector3 position;
    public Quaternion rotation; 
}
