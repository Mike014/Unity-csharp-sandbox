public class FileSystem
{
    private static FileSystem _instance;

    // Costruttore privato - nessuno può creare un'istanza dall'esterno
    private FileSystem() { }

    public static FileSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new FileSystem();
            return _instance;
        }
    }
}