using UnityEngine;

[CreateAssetMenu(fileName = "Screen", menuName = "Data", order = 0)]
public class SOItemData : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string itemDescription;
    public int price;
    public bool isConsumable = false;

    public virtual void Use(GameObject user)  // o Transform, o MonoBehaviour
    {
        Debug.Log(user.name + " used " + itemName);
    }
}


