// Superstato: rappresenta "essere a terra".
// Contiene la logica COMUNE a tutti gli stati terrestri.
// I sottostati ereditano e possono sovrascrivere.

public abstract class OnGroundState : IState
{
    public virtual void Enter(Entity entity)
    {
        
    }

    public virtual void HandleInput(Entity entity, InputType input)
    {
        // Logica COMUNE a tutti gli stati "a terra".
        // Scritta UNA volta, ereditata da tutti.

        if (input == InputType.PressJump)
        {
            // entity.ChangeActionState(HeroineStates.Jumping);
        }
        else if (input == InputType.PressDown)
        {
            // entity.ChangeActionState(new DuckingState());
        }
    }

    public virtual void Update(Entity entity)
    {
        
    }

    public virtual void Exit(Entity entity)
    {}
    
}
