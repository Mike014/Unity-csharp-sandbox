// L'ISTANZA SPECIFICA (Stato Estrinseco)
// I dati leggeri unici per ogni albero (Posizione, Scala, Colore).
using UnityEngine;

[System.Serializable]
public struct TreeInstance
{
    [Header("Flyweight Reference")]
    public TreeModelSO model; // Riferimento singolo ai dati pesanti condivisi

    [Header("Instance Data")]
    public Vector3 position;
    public float height;
    public float thickness;
    public Color barkTint;
    public Color leafTint;
}
