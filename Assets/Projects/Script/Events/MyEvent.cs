using UnityEngine;

// Prima modalità di implementazione di Eventi
public class MyEvent : MonoBehaviour
{
    public delegate void OnSomethingDelegate(int param1, string param2);
    public event OnSomethingDelegate OnSomething;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            // Il ?. evita NullReferenceException se nessuno è iscritto
            OnSomething?.Invoke(42, "hello");
        }
    }
}




