public static class HeroineStates 
{
    public static readonly IState Standing = new StandingState();
    // public static readonly IState Walking = new WalkingState();
    // public static readonly IState Running = new RunningState();
    public static readonly IState Jumping = new JumpingState();
    public static readonly IState Diving = new DivingState();

}
