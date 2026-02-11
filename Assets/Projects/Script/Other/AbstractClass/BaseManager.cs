using UnityEngine;

public abstract class BaseManager 
{
    // 2. Variabile 'protected': visibile solo a questa classe e ai suoi figli.
    // A differenza delle interfacce, qui POSSIAMO dare un valore iniziale.
    protected string _state = "Manager is not initialized...";
    // Livello di accesso che rende membri (variabili, metodi) accessibili solo all'interno della stessa classe o nelle classi derivate (sottoclassi).

    // Proprietà astratta: il figlio DOVRA' decidere come implementarla. 
    public abstract string State {get; set; }

    // Metodo astratto: non ha corpo { }, solo la firma
    public abstract void Initialize();
}