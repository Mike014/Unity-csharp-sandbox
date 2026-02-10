using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class BaseState : MonoBehaviour
{
    // Riferimento al controller per accedere ai dati (es. posizione player)
    protected FSMController controller;

    // Elenco delle transizioni possibili da questo stato
    protected List<BaseTransition> transitions = new List<BaseTransition>();

    private void Awake()
    {
        // AUTOMAZIONE: Trova tutte le transizioni attaccate allo stesso GameObject di questo stato
        // Così non devi trascinarle manualmente nella lista.
        transitions.AddRange(GetComponents<BaseTransition>());
    }

    // Chiamato dal Controller quando entra in questo stato
    public void Initialize(FSMController owner)
    {
        this.controller = owner;

        // Inizializziamo anche tutte le transizione collegate
        foreach (var transition in transitions)
        {
            transition.Initialize(owner);
        }
    }

    // Metodi virtuali che le sottoclassi (es. ChaseState) sovrascriveranno
    public virtual void StateEnter() {}
    public virtual void StateExit() {}
    public abstract void StateUpdate(); // Abstract obbliga a implementarlo

    // La funzione che controlla tutte le transizioni
    public BaseState CheckTransition()
    {
        foreach (BaseTransition transition in transitions)
        {
            if(transition.IsConditionMet())
            {
                return transition.TargetState;
            }
        }
        return null; // Nessun cambio di stato
    }
}

/*
Questa è la "superclasse" definita nella slide. Nota l'uso di abstract e virtual.

- Abstract
Una classe o metodo abstract è un "contratto incompiuto" che:
Non può essere istanziato direttamente (non puoi fare new ClasseAstratta())
Dichiara metodi senza implementazione che le classi figlie DEVONO implementare
Serve come "stampo" per creare gerarchie di classi con comportamenti comuni ma implementazioni diverse

- Virtual
Un metodo virtual è un metodo con implementazione di default che:
Può essere sovrascritto (override) nelle classi figlie, ma non è obbligatorio
Fornisce un comportamento base che le sottoclassi possono personalizzare
Usa il polimorfismo runtime (late binding)

- Il modificatore protected limita l'accesso a membri (metodi, proprietà, campi) solo alla classe in cui sono definiti e alle sue classi derivate (sottoclassi).


*/