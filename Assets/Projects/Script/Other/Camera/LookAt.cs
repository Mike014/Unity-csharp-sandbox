using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 3f;

    void Start()
    {
        if (_target == null)
        {
            Debug.Log("Camera have no Target!!!");
        }

        // 1. Calcoliamo la DIREZIONE dal Player verso la Camera attuale
        // Formula: Destinazione - Origine
        Vector3 directionFromTarget = transform.position - _target.position;

        // 2. Normalizziamo la direzione
        // Ora abbiamo una freccia che indica "da che parte sta la camera", lunga 1 metro
        directionFromTarget.Normalize();

        // 3. Calcoliamo la NUOVA posizione
        // Partiamo dal Player + andiamo nella direzione calcolata * per 3 metri
        Vector3 newPosition = _target.position + (directionFromTarget * _distance);

        // 4. Applichiamo la posizione
        transform.position = newPosition;

        // 5. Ruotiamo per guardare il target
        transform.LookAt(_target);
        
        Debug.Log($"Camera posizionata a {_distance} metri dal target.");
    }
}