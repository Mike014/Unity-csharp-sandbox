using System;
using UnityEngine;

// Le struct (Tipi Valore) vengono generalmente allocate nello Stack (memoria veloce e temporanea).
// BEST PRACTICE: Rendere le struct immutabili (readonly) per evitare bug di stato imprevedibili.
public struct PlayerStats{ public int Health; }

// Le classi (Tipi Riferimento) vengono allocate nell'Heap (memoria dinamica gestita dal Garbage Collector).
public class PlayerProfile : MonoBehaviour
{
    public int Score;

    void Start()
    {
        MemoryExample.DemonstrateStorage();
    }
}

public class ProfileData{ public int Score; }

public class MemoryExample
{
    public static void DemonstrateStorage()
    {
        // --- COMPORTAMENTO DEI TIPI VALORE ---
        PlayerStats stats1 = new PlayerStats { Health = 100 };
        PlayerStats stats2 = stats1; // COPIA PROFONDA (Deep Copy): i byte vengono duplicati in un'altra area di memoria.

        stats2.Health = 50;

        // Implicazione: Modificare stats2 non ha alcun impatto su stats1.
        UnityEngine.Debug.Log($"Stats1 Health : {stats1.Health}"); // Output: 100

        // --- COMPORTAMENTO DEI TIPI RIFERIMENTO ---
        ProfileData profile1 = new ProfileData { Score = 100 };
        ProfileData profile2 = profile1; // COPIA DEL PUNTATORE: profile2 ora punta alla stessa area di memoria di profile1.

        profile2.Score = 999;

        // Implicazione: Essendo alias della stessa istanza, la modifica è condivisa.
        UnityEngine.Debug.Log($"Profile1 Score: {profile1.Score}");
    }
}






