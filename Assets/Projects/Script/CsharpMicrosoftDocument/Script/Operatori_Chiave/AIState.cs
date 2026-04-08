using UnityEngine;

public abstract class AIState
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class PatrolState : AIState
{
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}

public class AIChaseState : AIState
{
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}