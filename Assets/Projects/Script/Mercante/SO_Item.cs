// ScriptableObject che rappresenta il singolo oggetto vendibile (Nome, Icona, Prezzo).
using UnityEngine;

public class SO_Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;

    public string Name => _name;
    public Sprite Icon => _icon;
    public int Price => _price;
}
