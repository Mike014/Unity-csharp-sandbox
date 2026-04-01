namespace GamePatterns.Observer
{
    /// Interfaccia per oggetti che vogliono essere notificati di eventi.
    public interface IObserver
    {
        void OnNotify(Entity entity, GamePatterns.Observer.GameEvent gameEvent);
    }
}
