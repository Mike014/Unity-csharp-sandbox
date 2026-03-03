using UnityEngine;

// L'attore: un qualsiasi oggetto nel gioco che può compiere azioni.
// Può essere il Player, un nemico o un veicolo
public class GameActor : MonoBehaviour
{
    public void Jump()
    {
        // Logica reale: rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log($"{gameObject.name} sta saltando!");
    }

    public void FireGun()
    {
        // Logica reale: Instantiate(bulletPrefab, gunBarrel.position, ...);
        Debug.Log($"{gameObject.name} sta sparando!");
    }
}
