using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkAsset;
    
    private Story _inkStory;

    void Awake()
    {
        InitializeStory();
    }

    void Start()
    {
        ContinueStory();
    }

    private void InitializeStory()
    {
        _inkStory = new Story(inkAsset.text);
        
        _inkStory.onError += (msg, type) =>
        {
            if (type == Ink.ErrorType.Warning)
                Debug.LogWarning(msg);
            else
                Debug.LogError(msg);
        };
    }

    private void ContinueStory()
    {
        // Accumula tutto il testo del blocco corrente
        string fullText = "";
        
        while (_inkStory.canContinue)
        {
            fullText += _inkStory.Continue();
        }

        // Emetti il testo accumulato
        if (!string.IsNullOrEmpty(fullText))
        {
            NarrativeEvents.OnStoryTextUpdated?.Invoke(fullText);
        }

        // Verifica se ci sono scelte o se la storia è finita
        if (_inkStory.currentChoices.Count > 0)
        {
            DisplayCurrentChoices();
        }
        else
        {
            NarrativeEvents.OnStoryEnded?.Invoke();
        }
    }

    private void DisplayCurrentChoices()
    {
        List<string> choiceTexts = new List<string>();

        for (int i = 0; i < _inkStory.currentChoices.Count; i++)
        {
            choiceTexts.Add(_inkStory.currentChoices[i].text);
        }

        NarrativeEvents.OnChoicesPresented?.Invoke(choiceTexts);
    }

    public void SelectChoice(int index)
    {
        if (index < 0 || index >= _inkStory.currentChoices.Count)
        {
            Debug.LogError($"Choice index {index} out of range.");
            return;
        }

        _inkStory.ChooseChoiceIndex(index);
        ContinueStory();
    }
}