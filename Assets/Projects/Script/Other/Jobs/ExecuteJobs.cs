using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

// CLASSE MonoBehaviour separata per eseguire il job
public class ExecuteJobs : MonoBehaviour
{
    void Start()
    {
        // 1. CREA NativeArray per il risultato
        // Size: 1 elemento (float)
        // Allocator.TempJob: memoria valida per max 4 frames
        NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

        // 2. ISTANZIA il job e assegna i dati
        MyJob job = new MyJob
        {
            a = 5,              // Input 1
            b = 3,              // Input 2
            result = result     // Output (riferimento al NativeArray)
        };

        // 3. ESEGUI il job
#if UNITY_EDITOR
        // In EDITOR: esegue SINCRONO sul main thread
        // Permette debug con breakpoint
        job.Run();
#else
        // In BUILD: esegue ASINCRONO su worker thread
        JobHandle handle = job.Schedule(); // Schedula il job
        handle.Complete();                 // Aspetta completamento
#endif

        // 4. LEGGI il risultato (dopo che il job è completato)
        Debug.Log($"Risultato: {result[0]}"); // Output: "Risultato: 8"

        // 5. LIBERA la memoria nativa (OBBLIGATORIO!)
        // Senza Dispose() → memory leak
        result.Dispose();
    }
}