using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Button[] _choiceButtons;
    [SerializeField] private StoryManager _storyManager;

    void HandleTextUpdate(string text)
    {
        _dialogueText.text = text;
    }

    void HandleChoices(List<string> choices)
    {
        // Prima nascondi tutti i bottoni
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            _choiceButtons[i].gameObject.SetActive(false);
        }

        // Poi attiva e configura solo quelli necessari
        for (int i = 0; i < choices.Count; i++)
        {
            _choiceButtons[i].gameObject.SetActive(true);
            
            // Prende il TMP_Text figlio del bottone
            TMP_Text buttonText = _choiceButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = choices[i];

            // Rimuove listener precedenti per evitare duplicati
            _choiceButtons[i].onClick.RemoveAllListeners();

            // Cattura l'indice in una variabile locale (closure)
            int choiceIndex = i;
            _choiceButtons[i].onClick.AddListener(() => OnChoiceClicked(choiceIndex));
        }
    }

    void OnChoiceClicked(int index)
    {
        // Nascondi i bottoni dopo la scelta
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            _choiceButtons[i].gameObject.SetActive(false);
        }

        _storyManager.SelectChoice(index);
    }

    void HandleStoryEnd()
    {
        _dialogueText.text += "\n\n[FINE]";
    }

    private void OnEnable()
    {
        NarrativeEvents.OnStoryTextUpdated += HandleTextUpdate;
        NarrativeEvents.OnChoicesPresented += HandleChoices;
        NarrativeEvents.OnStoryEnded += HandleStoryEnd;
    }

    private void OnDisable()
    {
        NarrativeEvents.OnStoryTextUpdated -= HandleTextUpdate;
        NarrativeEvents.OnChoicesPresented -= HandleChoices;
        NarrativeEvents.OnStoryEnded -= HandleStoryEnd;
    }
}
