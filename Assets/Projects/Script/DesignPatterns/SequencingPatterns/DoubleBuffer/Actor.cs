public class Actor
{
    private bool _currentSlapped; // Stato Corrente
    private bool _nextSlapped; // Stato prossimo

    public Actor()
    {
        _currentSlapped = false;
        _nextSlapped = false;
    }

    public virtual void Tick() { }
    public void Slap() => _nextSlapped = true;
    public bool WasSlapped() => _currentSlapped;
    public void Swap()
    {
        // Copia next → current
        _currentSlapped = _nextSlapped;

        // Resetta next per il prossimo frame
        _nextSlapped = false;
    }
}

public class Stage  
{
    private Actor[] actors = new Actor[3];

    public void Tick()
    {
        // Fase 1: tutti gli attori LEGGONO current e SCRIVONO next
        foreach (var actor in actors)
        {
            actor.Tick();
        }

        // Fase 2: tutti gli attori SWAPPANO in sincrono
        foreach (var actor in actors)
        {
            actor.Swap();
        }
    }


}

