using UnityEngine;

public class JumpCommand : IMyCommand
{
    public void Execute() => Debug.Log("Il giocatore salta!");
    public void Undo() => Debug.Log("Annulla salto - torna a terra");

}

public class FireCommand : IMyCommand
{
    public void Execute() => Debug.Log("Il giocatore spars!");
    public void Undo() => Debug.Log("Annulla sparo - ritira proiettile");
}

// Il "Null Object Pattern": un comando che non fa nulla.
// Evita i crash (NullReferenceException) se un tasto non è assegnato.
public class DoNothingCommand : IMyCommand
{
    public void Execute() { }
    public void Undo() {}
}
