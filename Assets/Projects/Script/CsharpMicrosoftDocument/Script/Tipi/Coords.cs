public struct Coords
{
    public double X { get; }
    public double Y { get; }

    public Coords(double x, double y) => (X, Y) = (x, y);

    public override string ToString() => $"{X}, {Y}";
}