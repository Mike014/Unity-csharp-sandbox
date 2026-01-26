using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Immagina un punto che si muove su un cerchio. La sua posizione può essere descritta da:
x = cos(angolo) × raggio
y = sin(angolo) × raggio
*/

public class OrbitSystem : MonoBehaviour
{

    [Header("Sfera Centrale")]
    [SerializeField] private GameObject _centralSphere; // ← Il "sole"

    [Header("Sfere Orbitanti - Setup")]
    [SerializeField] private GameObject _orbitingSpherePrefab; // ← Prefab della sfera
    [SerializeField] private int _numberOfSpheres = 5; // ← Quante sfere creare

    [Header("Parametri Orbita")]
    [SerializeField] private float _orbitRadius = 5f;  // ← Distanza dal centro
    [SerializeField] private float _minSpeed = 10f;    // ← Velocità minima (gradi/secondo)
    [SerializeField] private float _maxSpeed = 50f;    // ← Velocità massima

    // Array per tenere traccia delle sfere e dei loro parametri
    private GameObject[] _orbitingSpheres;
    private float[] _orbitSpeeds;  // ← Velocità di ogni sfera
    private float[] _currentAngles;  // ← Angolo attuale di ogni sfera

    void Start()
    {
        GenerateSpheres();
    }

    void Update()
    {
        UpdateOrbits();
    }

    void GenerateSpheres()
    {
        // ========================================
        // INIZIALIZZA GLI ARRAY
        // ========================================
        _orbitingSpheres = new GameObject[_numberOfSpheres];
        _orbitSpeeds = new float[_numberOfSpheres];
        _currentAngles = new float[_numberOfSpheres];

        // ========================================
        // CREA OGNI SFERA
        // ========================================
        for (int i = 0; i < _numberOfSpheres; i++)
        {
            // 1. CREA LA SFERA
            // Posizione iniziale temporanea (verrà aggiornata in Update)
            Vector3 initialPosition = _centralSphere.transform.position;
            _orbitingSpheres[i] = Instantiate(_orbitingSpherePrefab, initialPosition, Quaternion.identity);
            _orbitingSpheres[i].name = $"OrbitingSphere_{i}";

            // 2. ASSEGNA VELOCITÀ RANDOM
            _orbitSpeeds[i] = Random.Range(_minSpeed, _maxSpeed);

            // 3. ASSEGNA ANGOLO INIZIALE RANDOM (per distribuirle)
            _currentAngles[i] = Random.Range(0f, 360f);

            // 4. SCALA RANDOM (opzionale, per varietà visiva)
            float randomScale = Random.Range(0.1f, 0.25f);
            _orbitingSpheres[i].transform.localScale = Vector3.one * randomScale;
            Debug.Log($"Sfera {i}: Velocità = {_orbitSpeeds[i]:F1}°/s, Angolo iniziale = {_currentAngles[i]:F1}°");
        }
    }

    void UpdateOrbits()
    {
        Vector3 centerPos = _centralSphere.transform.position;

        // ========================================
        // AGGIORNA OGNI SFERA
        // ========================================
        for (int i = 0; i < _numberOfSpheres; i++)
        {
            // 1. INCREMENTA L'ANGOLO
            // Velocità × Time.deltaTime = spostamento questo frame
            _currentAngles[i] += _orbitSpeeds[i] * Time.deltaTime;

            // 2. MANTIENI L'ANGOLO TRA 0-360 (opzionale, ma pulito)
            if (_currentAngles[i] >= 360f)
            {
                _currentAngles[i] -= 360f;
            }

            // 3. CONVERTI ANGOLO IN RADIANTI
            // Unity usa radianti per Sin/Cos
            float angleInRadians = _currentAngles[i] * Mathf.Deg2Rad;

            // 4. CALCOLA POSIZIONE CON SIN/COS
            float x = Mathf.Cos(angleInRadians) * _orbitRadius;
            float z = Mathf.Sin(angleInRadians) * _orbitRadius;  // ← Usiamo Z invece di Y (piano orizzontale)

            // 5. APPLICA LA POSIZIONE (relativa al centro)
            Vector3 newPosition = centerPos + new Vector3(x, 0, z);
            _orbitingSpheres[i].transform.position = newPosition;
        }
    }
}
