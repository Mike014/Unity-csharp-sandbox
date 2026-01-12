using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    
    [Header("Buttons")]
    public Button newGameButton;
    public Button loadGameButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button exitButton;
    
    // [Header("Options Panel Buttons")]
    // public Button saveOptionsButton;
    // public Button returnFromOptionsButton;

    void Start()
    {
        // Assicurati che il pannello principale sia attivo
        // ShowMainMenu();
        
        // Disabilita il bottone Load Game (come richiesto)
        // if (loadGameButton != null)
        // {
        //     loadGameButton.interactable = false;
        // }
        
        // Collega i bottoni alle funzioni
        SetupButtons();
    }

    void SetupButtons()
    {
        if (newGameButton != null)
            newGameButton.onClick.AddListener(OnNewGame);
            
        if (loadGameButton != null)
            loadGameButton.onClick.AddListener(OnLoadGame);
            
        if (optionsButton != null)
            optionsButton.onClick.AddListener(OnOptions);
            
        if (creditsButton != null)
            creditsButton.onClick.AddListener(OnCredits);
            
        if (exitButton != null)
            exitButton.onClick.AddListener(OnExit);
            
        // if (saveOptionsButton != null)
        //     saveOptionsButton.onClick.AddListener(OnSaveOptions);
            
        // if (returnFromOptionsButton != null)
        //     returnFromOptionsButton.onClick.AddListener(ShowMainMenu);
    }

    // Bottone "New Game" - Carica il primo livello
    public void OnNewGame()
    {
        Debug.Log("Caricamento Level 1...");
        SceneManager.LoadScene("Scene1");
    }

    // Bottone "Load Game" - Non interagibile
    public void OnLoadGame()
    {
        Debug.Log("Load Game non disponibile");
    }

    // Bottone "Options" - Mostra il menù opzioni
    public void OnOptions()
    {
        Debug.Log("Apertura menù opzioni");
        // if (mainMenuPanel != null)
        //     mainMenuPanel.SetActive(false);
            
        // if (optionsPanel != null)
        //     optionsPanel.SetActive(true);
    }

    // Bottone "Credits" - Carica la scena dei crediti
    public void OnCredits()
    {
        Debug.Log("Caricamento crediti...");
        // SceneManager.LoadScene("Credits");
    }

    // Bottone "Exit" - Esce dal gioco
    public void OnExit()
    {
        Debug.Log("Sei uscito dal gioco");
        
        // #if UNITY_EDITOR
        // // In editor, ferma il play mode
        // UnityEditor.EditorApplication.isPlaying = false;
        // #else
        // // In build, chiude l'applicazione
        // Application.Quit();
        // #endif
    }

    // Bottone "Save Options" nel menù opzioni
    public void OnSaveOptions()
    {
        Debug.Log("Le opzioni sono state salvate");
        // ShowMainMenu();
    }

    // Mostra il menù principale
    // public void ShowMainMenu()
    // {
    //     if (mainMenuPanel != null)
    //         mainMenuPanel.SetActive(true);
            
    //     if (optionsPanel != null)
    //         optionsPanel.SetActive(false);
    // }
}