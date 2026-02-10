using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

// Questo script va sull'oggetto (es. Zombi)
public class FSMController : MonoBehaviour
{
    [Header("Setup")]
    // Trascina qui lo stato di partenza (es. l'oggeto "IdleState")
    public BaseState initialState;

    // Variabile per vedere lo stato attuale nell'Inspector (utile per debug)
    [SerializeField] private BaseState currentState;

    private void Start()
    {
        // Avvia la macchina a stati
        ChangeState(initialState);
    }

    private void Update()
    {
        if (currentState != null)
        {
            // Eseguiamo la logica dello stato corrente (es. muoviti)
            currentState.StateUpdate();

            // Controlliamo se ci sono transizioni valide
            BaseState nextState = currentState.CheckTransition();

            if (nextState != null)
            {
                ChangeState(nextState);
            }
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Usciamo dal vecchio stato
        if (currentState != null)
        {
            currentState.StateExit();
        }

        // Cambiamo riferimento
        currentState = newState;

        // Entriamo nel nuovo stato
        if (currentState != null)
        {
            // Inizializziamo lo stato passandogli questo controller
            // (Così lo stato sa chi deve comandare)
            currentState.Initialize(this);
            currentState.StateEnter();
        }
    }
}

/*
Questo è il "cuore" che batte. È l'unico MonoBehaviour che attacchi all'oggetto di gioco (es. il Nemico).
*/