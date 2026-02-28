using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class LightManager : MonoBehaviour
{
    public event UnityAction OnTurnOn;
    public event UnityAction OnTurnOff;

    public static LightManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnTurnOn?.Invoke();
            Debug.Log("Alpha1 is pressed");
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnTurnOff?.Invoke();
            Debug.Log("Alpha2 is pressed");
        }
    }
}
