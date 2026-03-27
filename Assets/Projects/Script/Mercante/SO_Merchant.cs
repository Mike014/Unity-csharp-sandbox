// ScriptableObject che definisce "l'identità" del mercante (Nome, e un array di SO_Item che rappresenta il suo catalogo).
using UnityEngine;

public class SO_Merchant : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private SO_Item[] _itemsToSell;

    public string Name => _name;
    public SO_Item[] ItemsToSell => _itemsToSell;
}
