public interface ICommand
{
    void Execute ();
    void Undo ();
}

/*
This interface can be used to define any command in your game that you want to happen or have a
state change. The execute function is called when we want the command to play out, and the undo
function is called to reverse the command.
*/