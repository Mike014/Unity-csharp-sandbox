using UnityEngine;

// CreateAssetMenu: crea il menu contestuale per generare l'asset
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public abstract class ItemSO : ScriptableObject
{
    // Public : visibili nell'inspector, editabili per ogni asset
    public int id; // Identificatore univoco
    public string itemName; // Nome mostrato al giocatore
    public string description; // Descrizione dettagliata
    public Sprite icon; // Icona UI

    // ABSTRACT: ogni tipo di item definirà il suo comportamento
    // GameObject target = chi usa l'item (es. il player)
    public abstract void Use(GameObject target);
}
