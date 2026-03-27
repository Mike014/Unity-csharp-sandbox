// Stato: in aria dopo un salto.
// Da qui si può: fare un'attacco in picchiata (PressDown).
// Non si può: saltare di nuovo (no air jump).

public class JumpingState : IState
{
    public void Enter(Entity entity)
    {
        // Transizione verso Diving (attacco in picchiata)
        entity.CurrentGraphics = "Jump";
        entity.VerticalVelocity = 5f;
    }

    public void Exit(Entity entity)
    {
        // Nessuna pulizia necessaria.
    }

    public void HandleInput(Entity entity, InputType input)
    {
        if (input == InputType.PressDown)
        {
            entity.ChangeState(new DivingState());
        }      
    }

    public void Update(Entity entity)
    {
        // Qui potresti applicare gravità, controllare atterraggio, ecc.
        // Per ora lasciato vuoto per semplicità.
    }
}
