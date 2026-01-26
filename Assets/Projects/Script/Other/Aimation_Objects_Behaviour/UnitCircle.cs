using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCircle : MonoBehaviour
{
    float thetaRad;
    float thetaDegrees = 0;
    float radius = 1;

    void Start()
    {
        // 1. Angle Conversion (Fundamental Step)
        /* In mathematics, θ (theta) is in radians.
           In Unity, the Inspector uses degrees. */
        thetaRad = thetaDegrees * Mathf.Deg2Rad;

        // 2. Parametric Equation (Coordinates)
        float x = Mathf.Cos(thetaRad) * radius;
        float y = Mathf.Sin(thetaRad) * radius;

        // 3. Fundamental Identity (Verification)
        // Mathf.Pow(value, power)
        float check = Mathf.Pow(x, 2) + Mathf.Pow(y, 2);
        Debug.Log(check);

        // 4. Position Vector
        Vector2 position = new Vector2(x, y);
        Debug.Log(position);
    }
}