using UnityEngine;
using Ink.Runtime;

// Wrapper MonoBehaviour per gestire una Story di Ink.
// "Script" nel senso cinematografico (sceneggiatura), non Unity script.
public class InkStoryManager : MonoBehaviour
{
    // ─────────────────────────────────────────────────────────────────
    // SERIALIZED FIELDS
    // ─────────────────────────────────────────────────────────────────
    
    [Header("Ink Asset")]
    [Tooltip("Il file .json compilato dal tuo .ink")]
    [SerializeField] private TextAsset _inkAsset;
    
    // ─────────────────────────────────────────────────────────────────
    // PRIVATE FIELDS
    // ─────────────────────────────────────────────────────────────────
    
    // L'oggetto Story è il runtime engine di Ink.
    // Contiene tutto lo stato narrativo: variabili, posizione, scelte.
    private Story _inkStory;
    
    // ─────────────────────────────────────────────────────────────────
    // UNITY LIFECYCLE
    // ─────────────────────────────────────────────────────────────────
    
    private void Awake()
    {
        InitializeStory();
    }
    
    // ─────────────────────────────────────────────────────────────────
    // INITIALIZATION
    // ─────────────────────────────────────────────────────────────────
    
    private void InitializeStory()
    {
        // Validazione: fallisci early se manca l'asset
        if (_inkAsset == null)
        {
            Debug.LogError($"[{nameof(InkStoryManager)}] Ink asset non assegnato!", this);
            return;
        }
        
        // Il costruttore di Story accetta il JSON come stringa.
        // TextAsset.text restituisce il contenuto del file come string.
        _inkStory = new Story(_inkAsset.text);
        
        // Registra l'error handler SUBITO dopo la creazione.
        // Cattura errori runtime di Ink (es. variabili mancanti, knot inesistenti).
        _inkStory.onError += HandleInkError;
    }
    
    // ─────────────────────────────────────────────────────────────────
    // CONTENT FLOW
    // ─────────────────────────────────────────────────────────────────
    
    // Avanza la storia e restituisce tutto il testo disponibile.
    public string GetNextContent()
    {
        // StringBuilder sarebbe più efficiente per molte concatenazioni,
        // ma per dialoghi tipici (poche righe) la differenza è trascurabile.
        var content = string.Empty;
        
        // canContinue è true finché c'è testo da leggere
        // prima del prossimo punto decisionale (choice) o fine storia.
        while (_inkStory.canContinue)
        {
            // Continue() restituisce UNA riga e avanza il puntatore interno.
            content += _inkStory.Continue();
        }
        
        return content;
    }
    
    // Verifica se ci sono scelte disponibili.
    public bool HasChoices => _inkStory.currentChoices.Count > 0;
    
    // Restituisce le scelte correnti come array di stringhe.
    public string[] GetCurrentChoices()
    {
        var choices = new string[_inkStory.currentChoices.Count];
        
        for (int i = 0; i < _inkStory.currentChoices.Count; i++)
        {
            choices[i] = _inkStory.currentChoices[i].text;
        }
        
        return choices;
    }
    
    // Seleziona una scelta per indice (0-based).
    public void MakeChoice(int index)
    {
        // Validazione per evitare IndexOutOfRange
        if (index < 0 || index >= _inkStory.currentChoices.Count)
        {
            Debug.LogError($"[{nameof(InkStoryManager)}] Indice scelta non valido: {index}", this);
            return;
        }
        
        _inkStory.ChooseChoiceIndex(index);
    }
    
    // ─────────────────────────────────────────────────────────────────
    // SAVE / LOAD
    // ─────────────────────────────────────────────────────────────────
    
    // Serializza lo stato corrente della storia in JSON.
    public string SaveState()
    {
        // state.ToJson() cattura TUTTO: posizione, variabili, visit counts.
        return _inkStory.state.ToJson();
    }
    
    // Ripristina lo stato della storia da un JSON salvato.
    public void LoadState(string savedJson)
    {
        if (string.IsNullOrEmpty(savedJson))
        {
            Debug.LogWarning($"[{nameof(InkStoryManager)}] JSON di salvataggio vuoto o nullo.", this);
            return;
        }
        
        _inkStory.state.LoadJson(savedJson);
    }
    
    // ─────────────────────────────────────────────────────────────────
    // ERROR HANDLING
    // ─────────────────────────────────────────────────────────────────
    
    private void HandleInkError(string message, Ink.ErrorType type)
    {
        // Ink distingue Warning (recuperabili) da Error (critici).
        // Mappiamo sui log Unity corrispondenti.
        if (type == Ink.ErrorType.Warning)
        {
            Debug.LogWarning($"[Ink Warning] {message}");
        }
        else
        {
            Debug.LogError($"[Ink Error] {message}");
        }
    }
    
    // ─────────────────────────────────────────────────────────────────
    // CLEANUP
    // ─────────────────────────────────────────────────────────────────
    
    private void OnDestroy()
    {
        // Disiscrivi l'evento per evitare memory leaks.
        // Buona pratica anche se Ink lo gestisce internamente.
        if (_inkStory != null)
        {
            _inkStory.onError -= HandleInkError;
        }
    }
}
