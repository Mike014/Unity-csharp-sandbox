using System.Collections;
using System.Collections.Generic;
using Unity.Collections;  // Per NativeArray
using Unity.Jobs;          // Per IJob e JobHandle
using UnityEngine;

// STRUCT del Job - implementa IJob
// Struct (value type) necessario per il Job System
public struct MyJob : IJob
{
    // INPUT: blittable types (vengono copiati nel job)
    public float a;
    public float b;
    
    // OUTPUT: NativeContainer (memoria condivisa con main thread)
    public NativeArray<float> result;

    // Metodo Execute: contiene la logica del job
    // Viene eseguito UNA VOLTA su UN SINGOLO CORE
    public void Execute()
    {
        // Calcola somma e scrive in memoria condivisa
        result[0] = a + b;
    }
}



/*
1. Start() chiamato da Unity
   ↓
2. Crea NativeArray in memoria nativa
   ↓
3. Crea istanza MyJob con dati
   ↓
4. Schedule/Run job
   ↓
5. Execute() eseguito (su main o worker thread)
   ↓
6. Complete() aspetta fine job
   ↓
7. Leggi result[0] dal main thread
   ↓
8. Dispose() libera memoria
*/