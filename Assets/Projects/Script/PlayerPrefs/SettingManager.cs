using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Slider _slider1;
    [SerializeField] private Slider _slider2;
    // [SerializeField] private Slider _slider3;

    [SerializeField] private Toggle _toggle1;

    void Update()
    {
        ResetSettings();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Slider1", _slider1.value);
        PlayerPrefs.SetFloat("Slider2", _slider2.value);
        // PlayerPrefs.SetFloat("Slider3", _slider3.value);
        PlayerPrefs.SetInt("Toggle1", _toggle1.isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Dati Salvati");

        PrintPlayerPrefsPath();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Slider1"))
        {
            _slider1.value = PlayerPrefs.GetFloat("Slider1");
            _slider2.value = PlayerPrefs.GetFloat("Slider2");
            // _slider3.value = PlayerPrefs.GetFloat("Slider3");
            _toggle1.isOn = PlayerPrefs.GetInt("Toggle1") == 1;
            Debug.Log("Dati Caricati");
        }
    }

    public void ResetSettings()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Rimuove tutto ciò che è stato salvato con PlayerPrefs per questo progetto
            PlayerPrefs.DeleteAll();

            // È buona norma chiamare Save() per confermare la pulizia sul disco/registro
            PlayerPrefs.Save();

            Debug.Log("Registro ripulito con successo!");

            // Opzionale: riporta gli elementi della UI ai valori di default
            _slider1.value = 0.0f;
            _slider2.value = 0.0f;
            _toggle1.isOn = true;

        }
    }

    void PrintPlayerPrefsPath()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        Debug.Log($"HKEY_CURRENT_USER\\Software\\{Application.companyName}\\{Application.productName}");
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        Debug.Log($"~/Library/Preferences/{Application.identifier}.plist");
#elif UNITY_STANDALONE_LINUX
        Debug.Log($"~/.config/unity3d/{Application.companyName}/{Application.productName}");
#endif
    }
}
