using UnityEngine;

public class SightTransition : BaseTransition
{
    [Header("Sensori")]
    public string playerTag = "Player";
    public float detectionRange = 10f;

    private Transform playerTransform;

    private void Start()
    {
        // Troviamo il player all'avvio per non cercarlo ogni frame (ottimizzazione)
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    public override bool IsConditionMet()
    {
        if (playerTransform == null) return false;

        // Calcoliamo la distanza tra lo Zombi (controller.transform) e il Player
        float distance = Vector3.Distance(controller.transform.position, playerTransform.position);

        // Se è minore del raggio, la condizione è vera -> CAMBIA STATO!
        return distance < detectionRange;
    }

    private void OnDrawGizmosSelected()
    {
        // Disegna una sfera rossa invisibile nel gioco ma visibile nell'editor
        Gizmos.color = Color.red;
        // Usa transform.parent perché lo script è sul figlio, ma la posizione è del padre
        if (transform.parent != null)
            Gizmos.DrawWireSphere(transform.parent.position, detectionRange);
    }
}