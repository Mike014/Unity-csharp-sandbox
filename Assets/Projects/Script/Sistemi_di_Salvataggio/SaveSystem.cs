using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string _key;
    private string _iv;

    [SerializeField] private Transform _player;

    private string _path => Application.persistentDataPath + "/data.sav";

    void Awake()
    {
        LoadOrGenerateKeys();
    }

    // Se KEY e IV esistono già in PlayerPrefs li carica, altrimenti li genera
    private void LoadOrGenerateKeys()
    {
        if (PlayerPrefs.HasKey("AES_KEY") && PlayerPrefs.HasKey("AES_IV"))
        {
            _key = PlayerPrefs.GetString("AES_KEY");
            _iv  = PlayerPrefs.GetString("AES_IV");
            Debug.Log("Chiavi caricate da PlayerPrefs");
        }
        else
        {
            using Aes aes = Aes.Create();
            _key = Convert.ToBase64String(aes.Key);
            _iv  = Convert.ToBase64String(aes.IV);

            PlayerPrefs.SetString("AES_KEY", _key);
            PlayerPrefs.SetString("AES_IV",  _iv);
            PlayerPrefs.Save();
            Debug.Log("Nuove chiavi generate e salvate");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) Save();
        if (Input.GetKeyDown(KeyCode.L)) Load();
        if (Input.GetKeyDown(KeyCode.D)) Delete();
    }

    private void Save()
    {
        SaveData data = new SaveData();
        data.position = _player.position;
        data.rotation = _player.rotation;

        string json = JsonUtility.ToJson(data, true);

        try
        {
            using FileStream stream = File.Create(_path);
            using Aes aes = Aes.Create();
            aes.Key = Convert.FromBase64String(_key);
            aes.IV  = Convert.FromBase64String(_iv);

            using ICryptoTransform encryptor = aes.CreateEncryptor();
            using CryptoStream cryptoStream = new CryptoStream(
                stream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(Encoding.UTF8.GetBytes(json));
            Debug.Log("Salvato (cifrato) in: " + _path);
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nel salvataggio: {e.Message}");
        }
    }

    private void Load()
    {
        if (!File.Exists(_path))
        {
            Debug.LogWarning("File non trovato!");
            return;
        }

        try
        {
            byte[] fileBytes = File.ReadAllBytes(_path);

            using Aes aes = Aes.Create();
            aes.Key = Convert.FromBase64String(_key);
            aes.IV  = Convert.FromBase64String(_iv);

            using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream memStream = new MemoryStream(fileBytes);
            using CryptoStream cryptoStream = new CryptoStream(
                memStream, decryptor, CryptoStreamMode.Read);

            using StreamReader reader = new StreamReader(cryptoStream);
            string json = reader.ReadToEnd();

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _player.position = data.position;
            _player.rotation = data.rotation;
            Debug.Log("Caricato da: " + _path);
        }
        catch (Exception e)
        {
            Debug.LogError($"Errore nel caricamento: {e.Message}");
        }
    }

    private void Delete()
    {
        if (File.Exists(_path))
        {
            File.Delete(_path);
            Debug.Log("File eliminato!");
        }
        else
        {
            Debug.LogWarning("Nessun file da eliminare!");
        }
    }
}