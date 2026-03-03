using UnityEngine;
using System.Collections.Generic;

public class CommandExecutor : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();
}