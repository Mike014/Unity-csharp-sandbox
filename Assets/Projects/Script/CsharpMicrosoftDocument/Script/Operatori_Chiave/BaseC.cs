using UnityEngine;

public class BaseC
{
    public static int x = 55;
    public static int y = 22;

    public class NestedC
    {
        public int x = 200;
    }
}

public class DerivedC : BaseC
{
    new public static int x = 100; // Nasconde BaseC.x

    new public class NestedC // Nasconde BaseC.NestedC
    {
        public int x = 100;
        public int z;
    }

    static void Main()
    {
        NestedC c1 = new NestedC(); // DerivedC.NestedC
        BaseC.NestedC c2 = new BaseC.NestedC();

        Debug.Log(x);
        Debug.Log(BaseC.x);
        Debug.Log(y);
    }
}