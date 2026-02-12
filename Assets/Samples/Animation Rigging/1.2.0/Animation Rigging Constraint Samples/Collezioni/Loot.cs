using UnityEngine;
using System.Linq;

public struct Loot
{
    public string name;
    public int rarity;

    // Costruttore per assegnare nome e rarità al momento della creazione
    public Loot(string name, int rarity)
    {
        this.name = name;
        this.rarity = rarity;
    }
}
