using UnityEngine;

// Classe astratta implementazione parziale
public abstract class abstractShape
{
    public string Color { get; set; }

    // Costruttore - inizializzazione comune
    protected abstractShape(string color) => Color = color;

    // Metodo concreto - logica condivisa
    public void DisplayInfo() => Debug.Log($"Shape Colored {Color}");

    // Metodo astratto logica specifica
    public abstract double CalculateArea();
}

public class Square : abstractShape
{
    public double Side { get; set; }

    public Square(string color, double side) : base(color) => Side = side;

    public override double CalculateArea() => Side * Side;
}