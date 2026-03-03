using UnityEngine;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    private IMyCommand _buttonX;
    private IMyCommand _buttonY;
    private Stack<IMyCommand> _history = new Stack<IMyCommand>();
    /*
    Stack è una struttura dati LIFO — Last In, First Out. L'ultimo elemento inserito è il primo ad uscire.
    Analogia: una pila di piatti. Metti piatti sopra, togli sempre dall'alto.
    Stack<IMyCommand> _history = new Stack<IMyCommand>();
//      ↑ tipo        ↑ nome     ↑ istanza vuota
    */

    private void Start()
    {
        _buttonX = new JumpCommand();
        _buttonY = new FireCommand();
    }

    private void Update()
    {
        IMyCommand command = HandleInput();

        if (command != null)
        {
            command.Execute();
            _history.Push(command);
            PrintHistory();
        }

        if (Input.GetKeyDown(KeyCode.Z) && _history.Count > 0)
            _history.Pop().Undo();
            PrintHistory();
    }

    public IMyCommand HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.X)) return _buttonX;
        if (Input.GetKeyDown(KeyCode.Y)) return _buttonY;
        return null;
    }

    private void PrintHistory()
    {
        Debug.Log($"--- History ({_history.Count} comandi) ---");

        int i = _history.Count;
        foreach (IMyCommand cmd in _history)
            Debug.Log($"  [{i--}] {cmd.GetType().Name}");
    }
}