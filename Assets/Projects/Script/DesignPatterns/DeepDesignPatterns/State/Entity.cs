using UnityEngine;
using System.Collections.Generic;

// Entity è il "contesto" nel pattern State.
// Possiede lo stato corrente e delega ad esso il comportamento.
// Non contiene switch né logica condizionale sullo stato.

public class Entity : MonoBehaviour
{
    // STACK invece di singolo riferimento.
    // Lo stato corrente è sempre in cima (Peek).
    // Gli stati sotto sono "memoria" di dove tornare.
    private Stack<IState> _stateStack;

    // Riferimento allo stato corrente.
    // Tipo interfaccia: Entity non sa QUALE stato concreto sia,
    // sa solo che rispetta il contratto IState.
    private IState _currentState;

    // FSM 1: cosa sta FACENDO (Standing, Jumping, Ducking, Diving)
    private IState _actionState;

    // FSM 2: cosa sta PORTANDO (Unarmed, Armed)
    private IState _equipmentState;

    // Proprietà che gli stati possono modificare.
    // Sono pubbliche per semplicità — in produzione useresti
    // metodi dedicati o proprietà con setter controllati.
    public float VerticalVelocity;
    public string CurrentGraphics;

    private void Start()
    {
        // Stato iniziale: Standing.
        // L'Entity parte sempre da uno stato noto.
        _currentState = new StandingState();

        // IMPORTANTE: chiamiamo Enter anche sullo stato iniziale.
        // Altrimenti la configurazione iniziale non avviene.
        _currentState.Enter(this);

        // Inizializza ENTRAMBE le FSM.
        // _actionState = HeroineStates.Standing;
        // _actionState.Enter(this);

        _equipmentState = EquipmentStates.Unarmed;
        _equipmentState.Enter(this);
    }

    private void Update()
    {
        // DELEGA: Entity non sa cosa fare ogni frame.
        // Chiede allo stato corrente di gestirlo.
        // 'this' passa il riferimento a se stessa.
        _currentState.Update(this);

        // _actionState.Update(this);
        _equipmentState.Update(this);
    }

    // Chiamato dal sistema di input (es. da un InputManager).
    // Entity non interpreta l'input — lo passa allo stato.
    public void HandleInput(InputType input)
    {
        _currentState.HandleInput(this, input);
        _actionState.HandleInput(this, input);
        _equipmentState.HandleInput(this, input);
    }

    // Metodo per cambiare stato.
    // Solo Entity può cambiare il proprio stato corrente.
    // Gli stati chiamano questo metodo per richiedere una transizione.
    public void ChangeState(IState newState)
    {
        // 1. ESCI dallo stato corrente (pulizia)
        _currentState.Exit(this);

        // 2. Cambia riferimento
        _currentState = newState;

        // 3. ENTRA nel nuovo stato (configurazione)
        _currentState.Enter(this);
    }

    // Metodo per cambiare stato AZIONE.
    public void ChangeActionsStat(IState newState)
    {
        _actionState.Exit(this);
        _actionState = newState;
        _actionState.Enter(this);
    }


    // Metodo per cambiare stato EQUIPAGGIAMENTO.
    public void ChangeEquipmentState(IState newState)
    {
        _equipmentState.Exit(this);
        _equipmentState = newState;
        _equipmentState.Enter(this);
    }

    public void Fire()
    {
        Debug.Log("Fire");
    }

    public bool CanFire()
    {
        return false;
    }

    // PUSH: aggiunge stato in cima, diventa il corrente.
    // Lo stato precedente resta sotto, "congelato".
    public void PushState(IState newState)
    {
        // Non chiamiamo Exit sul vecchio stato — è solo "in pausa".
        _stateStack.Push(newState);
        newState.Enter(this);
    }
     
    // POP: rimuove stato corrente, torna al precedente.
    // Usato quando uno stato "temporaneo" termina.
    public void PopState()
    {
        if(_stateStack.Count > 0)
        {
            IState oldState = _stateStack.Pop();
            oldState.Exit(this);

            // Lo stato sotto torna attivo.
            // Potremmo chiamare un metodo "Resume" se necessario.
            if (_stateStack.Count > 0)
            {
                // Opzionale: notifica che sta riprendendo.
                // _stateStack.Peek().Resume(this);
            }
        }
    }
}