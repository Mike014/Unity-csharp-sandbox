// Contratto per tutti gli stati del menu.
// Ogni stato gestisce un "pannello" o "schermata" del menu.

using UnityEditor;

public interface IMenuState
{
    // Chiamato quando questo stato diventa attivo (push o resume).
    // Qui mostri il pannello UI corrispondente.
    void Enter(MenuController controller);

    // Chiamato quando questo stato viene rimosso o coperto.
    // Qui nascondi il pannello UI.
    void Exit(MenuController controller);

    // Chiamato ogni frame mentre lo stato è attivo.
    // Per menu semplici spesso vuoto, utile per animazioni.
    void Update(MenuController controller);

    // Gestisce l'input "Back" (es. tasto Escape).
    // Restituisce true se lo stato vuole fare Pop.
    bool HandleBack(MenuController controller);
}

/*
Canvas
├── MenuController (script: MenuController)
├── MainMenuPanel (GameObject)
│   ├── Title (Text)
│   ├── OptionsButton (Button)
│   ├── CreditsButton (Button)
│   └── QuitButton (Button)
├── OptionsPanel (GameObject, inizialmente disattivo)
│   ├── Title (Text)
│   ├── [... slider, toggle, ecc.]
│   └── BackButton (Button)
└── CreditsPanel (GameObject, inizialmente disattivo)
    ├── Title (Text)
    ├── CreditsText (Text)
    └── BackButton (Button)

Estensione: Sotto-Menu Options

Classe C#
public class AudioOptionsState : BaseMenuState
{
    public AudioOptionsState(MenuController controller) 
        : base(controller.AudioOptionsPanel)
    {
    }
}

Implementazione
// In MenuButtons o in un OptionsButtons separato:
public void OnAudioClicked()
{
    _menuController.PushState(new AudioOptionsState(_menuController));
}
```

Lo stack gestisce automaticamente la navigazione:
```
MainMenu → Options → Audio → (Back) → Options → (Back) → MainMenu

IMenuState   Contratto per tutti gli stati menu
BaseMenuState  Logica comune (mostra/nascondi pannello)
MenuController  Stack, Push, Pop, gestione input Back
MainMenuState, OptionsState, CreditsState   Comportamento specifico per schermata
MenuButtons  Bridge tra UI e MenuController
*/
