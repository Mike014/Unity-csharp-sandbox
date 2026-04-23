public class Worker
{
    private volatile bool _shouldStop;

    public void DoWork()
    {
        while (!_shouldStop) // Compiler non può cachare _shouldStop
        {
            // Lavoro...
        }
    }

    public void RequestStop()
    {
        _shouldStop = true;
    }
}

/*
Con volatile:

- Ogni lettura accede alla memoria (no cache in registro)
- Ogni scrittura va direttamente in memoria
- Previene riordinamento di letture/scritture intorno al campo volatile
*/