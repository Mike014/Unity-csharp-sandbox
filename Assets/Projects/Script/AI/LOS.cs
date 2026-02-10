using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOS : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    Vector3 targetPos;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float stoppingDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("PlayerPosition : " + targetPos);
    }

    void Update()
    {
        // 1. ACQUISIZIONE DATI
        targetPos = _player.transform.position;
        Vector3 directionToPlayer = targetPos - this.transform.position;
        float currentDistance = directionToPlayer.magnitude;

        // 2. DEBUG TESTUALE (Console)
        // Ci dice i numeri esatti. Utile se devi controllare se una coordinata è 0 o NaN
        Debug.Log($"Target Position [Coordinate]: {targetPos}");
        Debug.Log($"My Forward [Direzione]: {transform.forward}");
        Debug.Log($"Direction To Player [Coordinate]: {directionToPlayer}");
        Debug.Log($"Current Distance [Coordinate]: {currentDistance}");

        // 3. DEBUG VISIVO (Scene View)
        // Ci fa capire intuitivamente cosa sta succedendo nello spazio

        // Linea ROSSA: "Dove dovrei guardare" (dal me al player)
        Debug.DrawLine(transform.position, targetPos, Color.red);

        // Raggio VERDE: "Dove sto guardando adesso" (il mio naso)
        // Moltiplico * 5 per allungare la freccia verde, altrimenti sarebbe lunga solo 1 metro
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);

        // 4. AZIONE FISICA
        transform.LookAt(targetPos);

        // 5. MOVE TO
        // Vector3 moveTo = targetPos - this.transform.position;
        // moveTo.Normalize();
        // this.transform.position += moveTo * speed * Time.deltaTime;
        /*
        NuovaPosizione = PosizioneAttuale + (Direzione * Velocità * Tempo)
        */
        if (currentDistance > stoppingDistance)
        {
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * speed * Time.deltaTime;
            Debug.Log("MI STO AVVICINANDO");
        }
        else
        {
            Debug.Log("🛑 DISTANZA RAGGIUNTA - FERMO");
        }
    }
}
