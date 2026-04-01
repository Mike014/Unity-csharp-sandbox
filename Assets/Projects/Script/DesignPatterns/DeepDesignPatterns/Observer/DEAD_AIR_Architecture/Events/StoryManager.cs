using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using DeadAir.Events;

namespace DeadAir.Narrative
{
    public class StoryManager : MonoBehaviour
    {
        #region Attributi
        // Serialized Fields
        [Header("Ink Story")]
        [SerializeField] private TextAsset _inkAsset;

        // [Header("Debug")]
        // [SerializeField] private bool _logToConsole = true;

        // Private Fields
        private Story _story;
        private bool _isInitialized;
        private bool _waitingForInput;
        private bool _waitingForChoice;
        // private List<Choice> _currentChoices = new List<Choice>();
        #endregion

        // Unity Lifecycle
        #region  Unity Lifecycle
        private void Awake()
        {
            // InitializeStory();
        }
        private void OnEnable()
        {
            // Subscribe a OnContinueRequested e OnChoiceSelected
            
        }
        private void OnDisable()
        {
            // Unsubscribe
        }

        private void Start()
        {
            if (_isInitialized)
                return;

            /* if (_isInitialized)
                ContinueStory(); */
        }
        #endregion

        #region Methods
        // Da implentare
        private void InitializeStory()
        {
            // ...
        }
        private void ContinueStory() {}
        private bool ProcessLine(string text, List<string> tags)
        {
            return true;
        }
        private void PresentChoices() {}
        private void HandleContinueRequested() {}
        private void HandleChoiceSelected(int index) {}
        private void HandleStoryEnd() {}
        private void HandleInkError(string message, Ink.ErrorType type) {}
        private void Log(string message) {} 
        #endregion
    }
}


