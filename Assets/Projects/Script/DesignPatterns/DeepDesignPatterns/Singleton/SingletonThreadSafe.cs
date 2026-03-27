public class FileSystemThreadSafe
{
    // Inizializzato una sola volta, thread - safe per specifica C#
    private static readonly FileSystemThreadSafe _instance = new FileSystemThreadSafe();

    private FileSystemThreadSafe() {}

    public static FileSystemThreadSafe Instenca => _instance;
}