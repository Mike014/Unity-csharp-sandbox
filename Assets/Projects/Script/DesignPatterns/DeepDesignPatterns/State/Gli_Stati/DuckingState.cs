using UnityEngine;

public class DuckingState : IState
{
    // Tempo di caricamento dell'attacco speciale.
    // INCAPSULATO nello stato — non inquina Entity
    private float _chargeTime;

    // Soglia per l'attacco speciale.
    private const float MaxChargeTime = 2f;

    public void Enter(Entity entity)
    {
        entity.CurrentGraphics = "Duck";

        // IMPORTANTE: reset del timer all'ingresso.
        // Prima questo codice era sparso in HandleInput di altri stati.
        // Ora è QUI, dove ha senso.
        _chargeTime = 0f;
    }

    public void Exit(Entity entity)
    {
        // Esempio di Exit utile:
        // se stavi caricando un attacco e vieni interrotto,
        // potresti voler salvare il progresso o resettare qualcosa.
        Debug.Log($"Exiting Duck. Charge was: {_chargeTime}");
    }

    public void HandleInput(Entity entity, InputType input)
    {
        if (input == InputType.ReleaseDown)
        {
            entity.ChangeState(new StandingState());
        }
    }

    public void Update(Entity entity)
    {
        // Logica ESCLUSIVA di Ducking: carica l'attacco.
        _chargeTime += Time.deltaTime;

        if (_chargeTime >= MaxChargeTime)
        {
            // Attacco speciale!
            // Qui potresti chiamare entity.PerformSuperAttack()
            // Per ora stampiamo solo un log.
            Debug.Log("Super Bomb");

            // Reset o transizione — dipende dal game design.
            _chargeTime = 0f;
        }
    }
}
