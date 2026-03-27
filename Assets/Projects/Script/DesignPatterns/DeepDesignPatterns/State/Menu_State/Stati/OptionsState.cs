using UnityEngine;

// Stato: schermata opzioni.
// Da qui si può tornare a MainMenu (Back/Pop).

public class OptionsState : BaseMenuState
{
    public OptionsState(MenuController controller) 
        : base(controller.OptionsPanel)
    {
    }
    
    // HandleBack usa il default di BaseMenuState (return true = Pop).
}