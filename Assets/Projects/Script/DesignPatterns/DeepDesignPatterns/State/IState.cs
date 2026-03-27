// Contratto che ogni stato concreto deve rispettare.
// Usiamo un'interfaccia perché:
// - Non c'è logica condivisa da ereditare
// - Massima flessibilità: una classe può implementare più interfacce
// - Forza ogni stato a dichiarare esplicitamente i metodi richiesti

public interface IState
{
    // Gestisce l'input ricevuto dall'entità.
    // Parametro 'entity': riferimento al proprietario dello stato,
    // così lo stato può modificarne le proprietà (velocità, grafica, ecc.)
    void HandleInput(Entity entity, InputType input);

    // Logica eseguita ogni frame mentre si è in questo stato.
    // Alcuni stati potrebbero non fare nulla qui — implementazione vuota.
    void Update(Entity entity);

    // NUOVO: chiamato quando si ENTRA in questo stato.
    // Lo stato configura l'entity come necessario.
    void Enter(Entity entity);

    // NUOVO: chiamato quando si ESCE da questo stato.
    // Pulizia, reset, salvataggio dati, ecc.
    void Exit(Entity entity);
}
