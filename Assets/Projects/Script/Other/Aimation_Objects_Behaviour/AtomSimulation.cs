using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSimulation : MonoBehaviour
{
    private class ElectronData
    {
        public Transform transform; 
        public float angle;         
        public float speed;         
        public Quaternion tilt;     
        public LineRenderer trail; 
    }

    [Header("Il Nucleo")]
    [SerializeField] private Transform _nucleus; 

    [Header("Guscio Elettronico")]
    [SerializeField] private GameObject _electronPrefab;
    [SerializeField] private int _electronCount = 6; 

    [Header("Fisica Atomica")]
    [SerializeField] private float _shellRadius = 3f;  
    [SerializeField] private float _electronSpeed = 180f; 

    [Header("Impostazioni Grafiche Orbita")]
    [SerializeField] private float _lineWidth = 0.05f; // Spessore della linea
    [SerializeField] private Material _lineMaterial;   // Materiale della linea (Es. Default-Line)
    [SerializeField] private int _segments = 60;       // Risoluzione del cerchio (più alto = più liscio)

    private List<ElectronData> _electrons = new List<ElectronData>();

    void Start()
    {
        GenerateAtom();
    }

    void Update()
    {
        VisualizeOrbitals();
    }

    void GenerateAtom()
    {
        for (int i = 0; i < _electronCount; i++)
        {
            // 1. Istanziamo l'Elettrone
            GameObject electronObj = Instantiate(_electronPrefab, _nucleus.position, Quaternion.identity);
            electronObj.name = $"Electron_{i}";
            
            // Colore casuale
            Color electronColor = Random.ColorHSV(0.0f, 1f, 1f, 1f, 1f, 1f);
            electronObj.GetComponent<Renderer>().material.color = electronColor;

            // 2. Setup Dati
            ElectronData data = new ElectronData();
            data.transform = electronObj.transform;
            data.angle = Random.Range(0f, 360f);
            data.speed = Random.Range(_electronSpeed * 0.8f, _electronSpeed * 1.2f);
            data.tilt = Random.rotation;

            // 3. SETUP LINE RENDERER (Disegno dell'orbita)
            // Aggiungiamo il componente LineRenderer direttamente all'elettrone
            LineRenderer lr = electronObj.AddComponent<LineRenderer>();
            
            // Configurazioni estetiche
            lr.startWidth = _lineWidth;
            lr.endWidth = _lineWidth;
            lr.material = _lineMaterial != null ? _lineMaterial : new Material(Shader.Find("Sprites/Default")); // Fallback se non assegni materiale
            lr.startColor = new Color(electronColor.r, electronColor.g, electronColor.b, 0.3f); // Colore semitrasparente
            lr.endColor = new Color(electronColor.r, electronColor.g, electronColor.b, 0.3f);
            lr.positionCount = _segments + 1; // +1 per chiudere il cerchio
            lr.useWorldSpace = true; // Usiamo coordinate globali così le linee seguono il nucleo se si muove
            lr.loop = true;          // Chiude automaticamente l'ultimo punto col primo

            data.trail = lr;

            _electrons.Add(data);
        }
    }

    void VisualizeOrbitals()
    {
        if (_nucleus == null) return;

        foreach (var e in _electrons)
        {
            // --- A. MOVIMENTO ELETTRONE ---
            e.angle += e.speed * Time.deltaTime;
            if (e.angle >= 360f) e.angle -= 360f;

            float rad = e.angle * Mathf.Deg2Rad;
            Vector3 flatPosition = new Vector3(Mathf.Cos(rad) * _shellRadius, 0, Mathf.Sin(rad) * _shellRadius);
            Vector3 atomicPosition = e.tilt * flatPosition;
            e.transform.position = _nucleus.position + atomicPosition;

            // --- B. DISEGNO ORBITA (LineRenderer) ---
            // Ricalcoliamo i punti dell'orbita ogni frame così se muovi il nucleo le linee lo seguono
            DrawOrbit(e);
        }
    }

    // Funzione dedicata per calcolare i punti del cerchio 3D
    void DrawOrbit(ElectronData e)
    {
        float angleStep = 360f / _segments;

        for (int i = 0; i <= _segments; i++)
        {
            float currentAngle = i * angleStep * Mathf.Deg2Rad;

            // Stessa matematica usata per l'elettrone, ma per ogni punto del cerchio
            Vector3 flatPos = new Vector3(Mathf.Cos(currentAngle) * _shellRadius, 0, Mathf.Sin(currentAngle) * _shellRadius);
            Vector3 finalPos = _nucleus.position + (e.tilt * flatPos);

            e.trail.SetPosition(i, finalPos);
        }
    }
}
