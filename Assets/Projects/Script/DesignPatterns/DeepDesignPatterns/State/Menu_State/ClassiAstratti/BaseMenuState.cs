using UnityEngine;

// Classe base opzionale che semplifica la creazione di stati.
// Fornisce implementazioni di default vuote.
// Gli stati concreti sovrascrivono solo ciò che serve.

public abstract class BaseMenuState : IMenuState
{
    // Riferimento al pannello UI che questo stato controlla.
    // Assegnato nel costruttore di ogni stato concreto.
    protected GameObject Panel { get; private set; }
    
    protected BaseMenuState(GameObject panel)
    {
        Panel = panel;
    }
    
    public virtual void Enter(MenuController controller)
    {
        // Default: mostra il pannello.
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    
    public virtual void Exit(MenuController controller)
    {
        // Default: nascondi il pannello.
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    
    public virtual void Update(MenuController controller)
    {
        // Default: nessuna logica per frame.
    }
    
    public virtual bool HandleBack(MenuController controller)
    {
        // Default: permetti Pop (torna indietro).
        return true;
    }
}
