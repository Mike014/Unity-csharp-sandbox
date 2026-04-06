using System;
using UnityEngine;

[Flags]
public enum Days
{
    None = 0, // 0b_0000_0000 = 0
    Monday = 1, // 0b_0000_0001 = 1
    Tuesday = 2, // 0b_0000_0010 = 2
    Wednesday = 4, // 0b_0000_0100 = 4
    Thursday = 8, // 0b_0000_1000 = 8
    Friday = 16, // 0b_0001_0000 = 16
    Saturday = 32, // 0b_0010_0000 = 32
    Sunday = 64, // 0b_0100_0000 = 64
    Weekend = Saturday | Sunday // Combinazione predefinita
}

public class Main : MonoBehaviour
{
    Days meetingsDays = Days.Monday | Days.Wednesday | Days.Friday;

    void Start()
    {
        Debug.Log("meetingsDays");
    }
}