using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using CustomExtensions;
using System.Linq;

public class GameBehaviour : MonoBehaviour, IManager
{
    #region Fields
    // public Variables
    public Stack<Loot> LootStack = new Stack<Loot>();

    // Costanti  
    const int value = 35;

    // Dati dell'Interfaccia IManager
    private string _state;

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
    #endregion

    #region Methods
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value; // 
        }
    }
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    void Start()
    {
        // Valore della const stampata a schermo
        Debug.Log("Questo è il const value : " + value);

        IManager manager = FindObjectOfType<GameBehaviour>();
        manager.Initialize();

        // Inizializza: All'avvio scriviamo i valori di default
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;
        winButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }
    public void Initialize()
    {
        _state = "Game Manager initialized...";

        // Aggiungiamo oggetti alla pila
        LootStack.Push(new Loot("Sword of Doom", 5));
        LootStack.Push(new Loot("HP Boost", 1));
        LootStack.Push(new Loot("Golden Key", 3));
        LootStack.Push(new Loot("Pair of Winged Boots", 2));
        LootStack.Push(new Loot("Mythril Bracer", 4)); // Questo sarà il PRIMO a essere estratto

        // Utilizzo la Custom Extensions
        _state.FancyDebug();

        Debug.Log(_state);
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
        /* 
        Debug.Log("RestartScene() è stato chiamato!");
        // MOSTRA IL CURSORE per permettere al giocatore di cliccare
        Cursor.lockState = CursorLockMode.Confined;
        // Ricarica il Livello
        // Carica la scena all'indice 0 (la prima nella lista del progetto)
        SceneManager.LoadScene(0);
        //Ripristiana il tempo
        // Se non lo fai il gioco rimarrà fermo
        Time.timeScale = 1f;
        Debug.Log("Scena ricaricata!");
        */

        // Classe statica, non ha bisongo di essere dichiaraa new Utilities()
        // Utilities.RestartLevel();
        // Overload della RestartLevel
        Utilities.RestartLevel();

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PrintLootReport()
    {
        // Rimuove e restituisce l'ulimo oggetto aggiunto (LIFO)
        var currentItem = LootStack.Pop();

        // Guarda l'oggetto che ora si trova in cima, senza rimuoverlo
        // Con "var". Il compilatore deduce automaticamente il tipo dalla parte destra dell'assegnazione.
        var nextItem = LootStack.Peek();

        // 3. Stampa il loot ottenuto e un'anticipazione del prossimo
        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!",
                        currentItem.name, nextItem.name);

        // Mostra quanti elementi rimangono nello Stack
        Debug.LogFormat("There are {0} random loot items waiting for you!", LootStack.Count);
    }

    public void FilterLoot()
    {
        // var rareLoot = LootStack.Where(item => item.rarity >= 3);
        var rareLoot = LootStack
            .Where(item => item.rarity >= 3)
            .OrderBy(item => item.rarity);

        foreach (var item in rareLoot)
        {
            Debug.LogFormat("Rare item: {0}!", item.name);
        }
    }

    public bool LootPredicate(Loot loot)
    {
        return loot.rarity >= 3;
    }
    #endregion
}
