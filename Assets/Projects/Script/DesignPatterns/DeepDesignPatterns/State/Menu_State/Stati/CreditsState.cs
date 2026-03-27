using UnityEngine;

// Stato: schermata credits.
// Da qui si può tornare a MainMenu (Back/Pop).

public class CreditsState : BaseMenuState
{
    public CreditsState(MenuController controller) 
        : base(controller.CreditsPanel)
    {
    }
    
    // HandleBack usa il default di BaseMenuState (return true = Pop).
}