using UnityEngine;

// Componente da attaccare a un GameObject con i bottoni del menu.
// Collega i click dei bottoni al MenuController.

public class MenuButtons : MonoBehaviour
{
    // Riferimento al controller (assegnato da Inspector).
    [SerializeField] private MenuController _menuController;
    
    // === BOTTONI MAIN MENU ===
    
    public void OnOptionsClicked()
    {
        _menuController.PushState(new OptionsState(_menuController));
    }
    
    public void OnCreditsClicked()
    {
        _menuController.PushState(new CreditsState(_menuController));
    }
    
    public void OnQuitClicked()
    {
        _menuController.QuitGame();
    }
    
    // === BOTTONI OPTIONS / CREDITS ===
    
    public void OnBackClicked()
    {
        // Simula la pressione di Escape.
        // Oppure chiama direttamente PopState se preferisci.
        _menuController.PopState();
    }
}