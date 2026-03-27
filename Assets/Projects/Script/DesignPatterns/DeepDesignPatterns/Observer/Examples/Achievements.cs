using UnityEngine;

public class Achievements : MonoBehaviour, IObserver
{
    public void OnNotify(string entity, GameEvent gameEvent)
    {
        switch (gameEvent)
        {
            case GameEvent.EntityFell:
                Debug.Log($"[Achievement] {entity} è caduto! Badge sbloccato.");
                break;
        }
    }
}