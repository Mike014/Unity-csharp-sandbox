using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    // Singleton
    private static TimerManager _instance;

    public static TimerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Cerca nella scena
                _instance = FindObjectOfType<TimerManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject("TimerManager");
                    _instance = go.AddComponent<TimerManager>();
                } 
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else if (_instance != this) Destroy(gameObject);
    }

    // Riferimento al testo UI (trascinalo dall'Inspector!)
    public TextMeshProUGUI uiText;

    // Inserisci questo metodo dentro TimerManager.cs
    public IEnumerator StartCountdown(int seconds)
    {
        while (seconds > 0)
        {
            // Aggiorna il testo con il numero corrente
            if (uiText != null) uiText.text = seconds.ToString();

            // Aspetta 1 secondo reale
            yield return new WaitForSeconds(1f);

            // Diminuisce il conteggio
            seconds--;
        }

        // Facoltativo: mostra "GO!" alla fine
        if (uiText != null) uiText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        if (uiText != null) uiText.text = "";
    }
}
