using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Semaforo : MonoBehaviour
{
    [Header("Riferimenti Luci")]
    [SerializeField] private Renderer _luceVerde;
    [SerializeField] private Renderer _luceGialla;
    [SerializeField] private Renderer _luceRossa;

    [Header("Materiali")]
    [SerializeField] private Material _matVerdeAcceso;
    [SerializeField] private Material _matVerdeSpento; // Ho corretto "SPento" in "Spento"
    [SerializeField] private Material _matGialloAcceso;
    [SerializeField] private Material _matGialloSpento;
    [SerializeField] private Material _matRossoAcceso;
    [SerializeField] private Material _matRossoSpento;

    [Header("UI")]
    [SerializeField] private Text _textCountdown;

    [Header("Timing")]
    [SerializeField] private float _durataVerde = 3f;
    [SerializeField] private float _durataGiallo = 1.5f;
    [SerializeField] private float _durataRosso = 3f;

    void Start()
    {
        // Avvia il ciclo del semaforo
        StartCoroutine(CicloSemaforo());
    }

    // ========================================
    // FUNZIONI DI CONTROLLO LUCI
    // ========================================

    void AttivaLuceVerde()
    {
        _luceVerde.material = _matVerdeAcceso;
        _luceGialla.material = _matGialloSpento;
        _luceRossa.material = _matRossoSpento;
    }

    void AttivaLuceGialla()
    {
        _luceVerde.material = _matVerdeSpento;
        _luceGialla.material = _matGialloAcceso;
        _luceRossa.material = _matRossoSpento;
    }

    void AttivaLuceRossa()
    {
        _luceVerde.material = _matVerdeSpento;
        _luceGialla.material = _matGialloSpento;
        _luceRossa.material = _matRossoAcceso;
    }

    IEnumerator CicloSemaforo()
    {
        while (true)  // ← Loop infinito
        {
            // ========================================
            // FASE 1: VERDE
            // ========================================
            AttivaLuceVerde();
            yield return StartCoroutine(MostraCountdown(_durataVerde, "VERDE"));
            
            // ========================================
            // FASE 2: GIALLO
            // ========================================
            AttivaLuceGialla();
            yield return StartCoroutine(MostraCountdown(_durataGiallo, "GIALLO"));
            
            // ========================================
            // FASE 3: ROSSO
            // ========================================
            AttivaLuceRossa();
            yield return StartCoroutine(MostraCountdown(_durataRosso, "ROSSO"));
            
            // Il ciclo ricomincia automaticamente!
        }
    }

    // ========================================
    // COROUTINE COUNTDOWN
    // ========================================
    IEnumerator MostraCountdown(float durata, string colore)
    {
        float tempoRimanente = durata;
        
        while (tempoRimanente > 0)
        {
            // Aggiorna il testo del countdown
            _textCountdown.text = $"Il semaforo si aggiorna tra {tempoRimanente:F1} secondi\n[{colore}]";
            
            // Aspetta un frame
            yield return null;
            
            // Decrementa il tempo
            tempoRimanente -= Time.deltaTime;
        }
    }
}

