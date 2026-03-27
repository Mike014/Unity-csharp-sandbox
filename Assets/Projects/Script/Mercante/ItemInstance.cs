// Classe base (non MonoBehaviour) che unisce il dato statico (SO_Item) alla quantità posseduta (Amount).
using UnityEngine;

public class ItemInstance 
{
    [SerializeField] private SO_Item _data;
    [SerializeField] private int _amount;

    public SO_Item Data => _data;
    // public int Amount => _amount;

    public ItemInstance(SO_Item itemData, int amount)
    {
        _data = itemData;
        _amount = amount;
    }

    public int Amount
    {
        get => _amount;
        set => _amount = Mathf.Max(0, value);
    }
}
