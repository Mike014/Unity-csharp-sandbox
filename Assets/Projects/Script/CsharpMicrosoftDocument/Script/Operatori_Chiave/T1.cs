public class T1
{
    public static int publicInt; // Accessibile ovunque
    internal static int internalInt; // Solo nell'assembly
    private static int _privateInt = 0; // Solo dentro T1

    public class M1 // Classe annidata public 
    {
        public static int publicInt; // Sembra public, MA...
    }

    private class M2 // Classe annidata private 
    {
        public static int publicInt = 0; // Sembra public, Ma...
    }
}

class T1Test
{
    void Example()
    {
        T1.publicInt = 1; // OK - T1 è public, campo è public
        T1.internalInt = 2; // OK - stesso assembly
        // T1._privateInt = 3;
    }
}