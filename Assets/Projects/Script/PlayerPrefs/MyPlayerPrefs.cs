using System.Collections;
using UnityEngine;

public class MyPlayerPrefs : MonoBehaviour
{
    #region Costanti e Cache
    private const string KEY_INT = "HighScore";
    private const string KEY_FLOAT = "VolumeLevel";
    private const string KEY_STRING = "PlayerName";
    private readonly WaitForSeconds _waitThreeSeconds = new WaitForSeconds(3.0f);
    #endregion

    #region Variabili Private
    private int _intValue;
    private float _floatValue;
    private string _stringValue;
    private bool _isDirty = false;
    #endregion

    #region Proprietà Pubbliche
    public int IntValue
    {
        get => _intValue;
        set
        {
            if (_intValue == value) return;
            _intValue = value;
            _isDirty = true;
            PlayerPrefs.SetInt(KEY_INT, _intValue);
            Debug.Log($"[SaveSystem] Salvato nuovo valore per {KEY_INT}: {_intValue}");
        }
    }

    public float FloatValue
    {
        get => _floatValue;
        set
        {
            if (_floatValue == value) return;
            _floatValue = value;
            _isDirty = true;
            PlayerPrefs.SetFloat(KEY_FLOAT, _floatValue);
            Debug.Log($"[SaveSystem] Salvato nuovo valore per {KEY_FLOAT}: {_floatValue}");
        }
    }

    public string StringValue
    {
        get => _stringValue;
        set
        {
            if (_stringValue == value) return;
            _stringValue = value;
            _isDirty = true;
            PlayerPrefs.SetString(KEY_STRING, _stringValue);
            Debug.Log($"[SaveSystem] Salvato nuovo valore per {KEY_STRING}: {_stringValue}");
        }
    }
    #endregion

    #region Unity Lifecycle
    void Start()
    {
        LoadData();
        StartCoroutine(CheckKeysSequentially());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IntValue += 10;
            FloatValue += 3.0f;
            StringValue += "Valore";
        }

        if (_isDirty && Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.Save();
            _isDirty = false;
            Debug.Log("Dati scritti fisicamente su disco.");
        }
    }

    private void OnApplicationQuit()
    {
        if (_isDirty)
        {
            PlayerPrefs.Save();
            Debug.Log("Salvataggio automatico alla chiusura.");
        }
    }
    #endregion

    #region Metodi Privati
    private void LoadData()
    {
        _intValue = PlayerPrefs.GetInt(KEY_INT, 0);
        _floatValue = PlayerPrefs.GetFloat(KEY_FLOAT, 0.0f);
        _stringValue = PlayerPrefs.GetString(KEY_STRING, "Value");
    }

    IEnumerator CheckKeysSequentially()
    {
        while (true)
        {
            Debug.Log($"[Monitor] Valore attuale di {KEY_INT} in RAM: {IntValue}");
            yield return _waitThreeSeconds;
        }
    }
    #endregion
}