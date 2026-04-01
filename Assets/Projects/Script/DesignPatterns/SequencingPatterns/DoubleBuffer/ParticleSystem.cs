using UnityEngine;

struct Particle 
{
    Vector3 position; // 12 byte (3 float)
    Vector3 velocity; // 12 byte
    Color color; // 16 byte (4 float RGBA)
    float lifetime; // 4 byte
}

/*
Totale: 44 byte per particella

10.000 particelle × 44 byte = 440.000 byte ≈ 430 KB
*/