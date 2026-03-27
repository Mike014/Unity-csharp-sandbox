public class StandingState : IState
{
    public void Enter(Entity entity)
    {
        
        // Standing configura SE STESSO.
        // Non importa DA DOVE arrivi — Ducking, Jumping, Diving —
        // la grafica sarà sempre corretta.
        entity.CurrentGraphics = "Stand";
        entity.VerticalVelocity = 0f;
    }

    public void Exit(Entity entity)
    {
        
    }

    public void HandleInput(Entity entity, InputType input)
    {
        if (input == InputType.PressJump)
        {
            // NOTA: non settiamo più la grafica qui.
            // Sarà JumpingState.Enter() a farlo.
            entity.ChangeState(new JumpingState());
        }
        else if (input == InputType.PressDown)
        {
            entity.ChangeState(new DuckingState());
        }
    }

    public void Update(Entity entity)
    {
        // Standing non ha logica di update.
        // Il personaggio è fermo, non succede nulla ogni frame.
    }
}
