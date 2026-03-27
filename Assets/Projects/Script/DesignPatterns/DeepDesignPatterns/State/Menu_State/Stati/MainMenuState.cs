using UnityEngine;

// Stato: schermata principale del menu.
// Da qui si può andare a Options, Credits, o uscire dal gioco.

public class MainMenuState : BaseMenuState
{
    public MainMenuState(MenuController controller) 
        : base(controller.MainMenuPanel)
    {
    }

    public override bool HandleBack(MenuController controller)
    {
        // MainMenu è lo stato root.
        // Back qui potrebbe mostrare "Quit?" oppure essere ignorato.
        // Per ora ignoriamo (return false = non fare Pop).
        return false;
    }
}

