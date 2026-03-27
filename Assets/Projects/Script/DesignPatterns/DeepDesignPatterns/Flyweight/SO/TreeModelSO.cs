using UnityEngine;

[CreateAssetMenu(fileName = "NewTreeModel", menuName = "Environment/Tree Model")]
public class TreeModelSO : ScriptableObject
{
    // IL MODELLO CONDIVISO (Stato Intrinseco)
    // I dati pesanti uguali per tutti 
    [Header("Shared Heavy Data")]
    public Mesh mesh;
    public Material treeMaterial; // In Unity preferiamo usare i Materiali invece delle Texture grezze
}
