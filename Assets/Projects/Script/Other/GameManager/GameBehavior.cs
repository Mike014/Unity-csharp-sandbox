using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameBehavior : MonoBehaviour
{
    // DATI PRIVATI (Backing Variables)
    // Questi sono i dati reali, nascosti al mondo esterno.
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private bool _isPaused = false;
    private bool _isGameWon = false;

    // Variabili per le regole di gioco PUBBLICHE
    public int maxItems = 4;

    // Riferimenti agli oggetti UI 
    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;
    public Button lossButton;

    // Riferimento al pulsante (da trascinare dall'Inspector)
    public Button winButton;
    public Button pauseButton;

    public int HP
    {
        get { return _playerHP;}
        set 
        {
            _playerHP = value; // 
        }
    }

    void Start()
{
    // Inizializza: All'avvio scriviamo i valori di default
    itemText.text += _itemsCollected;
    healthText.text += _playerHP;
    winButton.gameObject.SetActive(false);
    pauseButton.gameObject.SetActive(false);
}

void Update()
{
    // Controlla se il gioco è vinto PRIMA di permettere la pausa
    if (Input.GetKeyDown(KeyCode.Tab) && !_isGameWon)
    {
        // Toggle: se paused, riprendi; altrimenti, metti in pausa
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            pauseButton.gameObject.SetActive(true);
            winButton.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pauseButton.gameObject.SetActive(false);
            winButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

// 1. PROPRIETÀ PUBBLICA per gli Oggetti
// Notare che non ha parentesi () come un metodo, ma ha { get; set; }
public int Items
{
    // GET (Lettura): Chiunque chieda "Quanti oggetti ho?", riceve il valore di _itemsCollected.
    get { return _itemsCollected; }

    // SET (Scrittura): Chiunque scriva "Items = 5", attiva questo blocco.
    set
    {
        // 'value' è una parola chiave magica che contiene il nuovo numero inviato (es. 5)
        _itemsCollected = value;
        itemText.text = "Items Collected: " + Items;

        if (_itemsCollected >= maxItems)
        {
            progressText.text = "You've found all the items!";

            Cursor.lockState = CursorLockMode.None;

            // Imposta il flag _isGameWon = true
            _isGameWon = true;

            /*ATTIVAZIONE DEL PULSANTE
            Riaccendiamo il GameObject del pulsante per mostrarlo a schermo
            */
            winButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            // Qui potresti anche aggiungere: Time.timeScale = 0; per mettere in pausa
            Time.timeScale = 0f;

            // NOOO
            // Premi tasto BackSpace per ricominciare la scena
            // if(Input.GetKeyDown(KeyCode.Space))
            // {
            //     RestartScene();
            // }
        }
        else
        {
            progressText.text = "Item found, only " + (maxItems - _itemsCollected) + " more!";
            //    // Possiamo aggiungere logica extra! Qui stampiamo un log ogni volta che il valore cambia.
            //    Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
}

/*
METODO PER IL BOTTONE
Deve essere PUBLIC per poter essere visto dal sistema UI di Unity
*/
public void RestartScene()
{
    Debug.Log("RestartScene() è stato chiamato!");

    // MOSTRA IL CURSORE per permettere al giocatore di cliccare
    Cursor.lockState = CursorLockMode.Confined;

    // Ricarica il Livello
    // Carica la scena all'indice 0 (la prima nella lista del progetto)
    SceneManager.LoadScene(0);

    //Ripristiana il tempo
    // Se non lo fai il gioco rimarrà fermo
    Time.timeScale = 1f;

    Debug.Log("✅ Scena ricaricata!");
}
}