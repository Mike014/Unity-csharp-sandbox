using UnityEngine;

public struct StructPoint
{
    public int X;
    public int Y;
}

public class Test : MonoBehaviour
{
    StructPoint p = default; // X = 0, Y = 0
    
    void ModifyPoint(Point p)
    {
        p.X = 999;
    }

    void Awake()
    {
        Point original = new Point { X = 10, Y = 20 };
        ModifyPoint(original);
        Debug.Log(original.X);
    }
}

// Regola: Il valore predefinito di uno struct ha tutti i campi azzerati (pattern a 0-bit).