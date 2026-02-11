public interface IManager
{
    // Una proprietà che ogni manager deve avere
    string State { get; set;}

    void Initialize();
}