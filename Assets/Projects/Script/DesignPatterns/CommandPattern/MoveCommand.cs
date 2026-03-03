using UnityEngine;

public class MoveCommand : ICommand
{
    private PlayerMovement _playerMovement;
    private Vector3 _movement;

    public MoveCommand(PlayerMovement playerMovement, Vector3 movement)
    {
        _playerMovement = playerMovement;
        _movement = movement;
    }

    public void Execute()
    {
        _playerMovement.Move(_movement);
    }

    public void Undo()
    {
        _playerMovement.Move(-_movement);
    }
}

/*
MoveCommand class, which will implement the ICommand interface. This class
will contain the logic for the player’s movement command.
*/