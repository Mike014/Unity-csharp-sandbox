// hub statico per il pattern Observer.
// Un hub eventi statico permette a qualsiasi script di pubblicare/sottoscrivere senza riferimenti diretti.
// Comodo ma globale. Accettabile per un sistema narrativo centrale.
using System;
using System.Collections.Generic;

public class NarrativeEvents
{

    // Testo narrativo: trasporta una stringa
    public static Action<string> OnStoryTextUpdated;

    // Scelte: trasporta una lista di stringhe
    public static Action<List<string>> OnChoicesPresented;

    // Fine storia: serve trasportare dati?
    public static Action OnStoryEnded;
}
