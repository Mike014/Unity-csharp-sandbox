using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Health Potion")]
public class HealthPotionSO : ItemSO // Eredita da ItemSO
{
    public int healAmount = 50; // Quantità di HP ripristinati

    public override void Use(GameObject target) // override = implementazione concreta
    {
        // Cerca un componente che gestisca la salute
        // PlayerHealth health = target.GetComponent<PlayerHealth>();

        // Logica di implementazione della componente
    }

}
