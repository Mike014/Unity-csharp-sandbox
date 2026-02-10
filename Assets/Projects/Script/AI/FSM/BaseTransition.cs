using UnityEngine;

public abstract class BaseTransition : MonoBehaviour
{
    // Riferimento allo stato a cui punta questa transizione
    [Tooltip("Trascina qui il GameObject dello stato in cui vuoi andare")]
    public BaseState TargetState; // Parametro personalizzabile da Inspector

    // Riferimento al controller per controllare le condizioni (es. distanze)
    protected FSMController controller;

    public void Initialize(FSMController owner)
    {
        this.controller = owner;
    }

    // Funzione che restituisce true se la transizione deve avvenire
    public abstract bool IsConditionMet();
}