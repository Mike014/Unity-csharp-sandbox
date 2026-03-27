public class ArmedState : IState
{
    public void Enter(Entity entity)
    {
        
    }

    public void Exit(Entity entity)
    {
        
    }

    public void HandleInput(Entity entity, InputType input)
    {
        if (input == InputType.PressFire)
        {
            // Spara! L'azione avviene QUI, indipendentemente
            // dal fatto che l'Entity stia saltando, correndo, ecc.
            entity.Fire();
        }
    }

    public void Update(Entity entity)
    {
        
    }
}
