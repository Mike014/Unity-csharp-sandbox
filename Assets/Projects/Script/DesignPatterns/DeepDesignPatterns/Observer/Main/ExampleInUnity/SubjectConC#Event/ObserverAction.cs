using UnityEngine;

public class ObserverAction : MonoBehaviour
{
    // Esempio con fisica di sistema
    [SerializeField] private SubjectAction _subjects;

    private void Start() => _subjects.OnEntityEvent += OnEntityEvent;
    private void OnDestroy() => _subjects.OnEntityEvent -= OnEntityEvent;

    private void OnEntityEvent(string entity, GameEvent gameEvent)
    {
        if (gameEvent == GameEvent.EntityFell)
            Debug.Log($"[Achievement] {entity} è caduto!");
    }
}

/*
La differenza rispetto alla versione con interfaccia:
                    Interfaccia + Subject       C# event
Lista observer      manuale                     automatica
Registrazione       AddObserver()               +=
Deregistrazione     RemoveObserver()            -= 
GameManagernecessario SI                        NO
*/