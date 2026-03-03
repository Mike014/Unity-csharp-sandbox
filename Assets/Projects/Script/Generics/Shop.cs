using System.Collections.Generic;

public class Shop<T> where T : Collectable
{
    public List<T> inventory = new List<T>();

    public void AddItem(T newItem)
    {
        inventory.Add(newItem);
    }

    // La U è esattamente come la T. È semplicemente un altro nome "segnaposto" per un tipo di dato
    public int GetStockCount<U>() where U : T
    {
        var stock = 0;

        foreach (var item in inventory)
        {
            if (item is U)
            {
                stock++;
            }
        }
        return stock;
    }
}

/*
Implementazione in GameManager
var itemShop = new Shop<Collectable>();
itemShop.AddItem(new Potion());
itemShop.AddItem(new Antidote());
Debug.Log("Items for sale: " + itemShop.GetStockCount<Potion>());
*/



























// Puoi implementare il codice in questo modo
/*
public class GameManager : MonoBehaviour, IManager
{
    public void Initialize()
    {
        var itemShop = new Shop<string>();

        itemShop.AddItem("Potion");
        itemShop.AddItem("Antidote");
        Debug.Log("Items for sale: " + itemShop.inventory.Count);
    }
}
*/
