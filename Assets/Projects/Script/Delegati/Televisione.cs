using UnityEngine;

public class Televisione : MonoBehaviour
{
    public Telecomando ilMioTelecomando;

    // CORRETTO: OnEnable (con la E maiuscola)
    void OnEnable()
    {
        ilMioTelecomando.OnPulsantePremuto += Accendi;
        Debug.Log("TV: Iscrizione effettuata!"); // Debug per conferma
    }

    void OnDisable()
    {
        // Questo era corretto!
        ilMioTelecomando.OnPulsantePremuto -= Accendi;
    }

    void Accendi()
    {
        Debug.Log("TV Accesa.");
    }
}