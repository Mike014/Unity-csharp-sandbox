public class DivingState : IState
{
    public void Enter(Entity entity)
    {
        entity.CurrentGraphics = "Dive";

        // Imposta velocità verso il basso per la picchiata
        entity.VerticalVelocity = -10f;
    }

    public void Exit(Entity entity)
    {
        // 
    }
    
    public void HandleInput(Entity entity, InputType input)
    {
        // 
    }

    public void Update(Entity entity)
    {
        // 
    }
}