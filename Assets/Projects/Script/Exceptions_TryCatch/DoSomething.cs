using UnityEngine;

public sealed class DoSomething : MonoBehaviour
{
    [SerializeField] private string _text;

    void Awake()
    {
        _text = null;
    }

    void Start()
    {
        try
        {
            WriteSomething(_text);
        }
        catch (System.ArgumentNullException e)
        {
            Debug.LogWarning("Testo null: " + e.Message);
            WriteSomething("Fallback text");    // valore di default
        }
        finally
        {
            Debug.Log("WriteSomething completato");
        }
    }

    private void WriteSomething(string text)
    {
        if (text == null)
        {
            throw new System.ArgumentNullException(nameof(text), "Il testo non può essere null");
        }

        Debug.Log(text);
    }
}
