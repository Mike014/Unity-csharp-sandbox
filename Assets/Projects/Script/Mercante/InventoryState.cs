// Classe che gestisce una Lista di ItemInstance e i soldi del giocatore (Money). 
// Fornisce metodi logici puri come AddItem o la ricerca di un oggetto (FindItemIndex).
using System.Collections.Generic;
using UnityEngine;

public class InventoryState
{
    [SerializeField] private List<ItemInstance> _items = new List<ItemInstance>();
    [SerializeField] private int _money;

    public int Money { get => _money; set => _money = Mathf.Max(0, value); }

    private int FindItemIndex(SO_Item itemData)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Data == itemData) return i;
        }
        return -1; // segnalare che un elemento non è stato trovato all'interno di una collezione
    }

    public void AddItem(SO_Item itemData, int amount)
    {
        if (amount < 1) return;
        int index = FindItemIndex(itemData);
        if (index < 0) _items.Add(new ItemInstance(itemData, amount));
        else      _items[index].Amount += amount;
    }
}
