// Enum che rappresenta i possibili input del giocatore.
// Mutualmente esclusivi: un solo input alla volta viene processato.

public enum InputType
{
    None,
    PressJump,
    PressDown,
    ReleaseDown,
    PressFire,
    PressRight,
    ReleaseRight,
    PressRun,
    ReleaseRun
}