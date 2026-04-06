using System;

[Flags]
public enum DamageType
{
    None = 0,
    Physical = 1,
    Fire = 2,
    Ice = 4,
    Lightning = 8,
    Poison = 16,

    Elemental = Fire | Ice | Lightning
}