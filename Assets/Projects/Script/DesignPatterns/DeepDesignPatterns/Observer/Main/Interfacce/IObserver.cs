public interface IObserver
{
    void OnNotify(string Entity, GameEvent gameEvent);
}