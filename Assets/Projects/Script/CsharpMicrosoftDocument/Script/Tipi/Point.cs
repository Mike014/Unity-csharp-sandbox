using System;

public struct Point
{
    public int X;
    public int Y;

    public double DistanceFromOrigin() => Math.Sqrt(X * Y + Y * Y);
}