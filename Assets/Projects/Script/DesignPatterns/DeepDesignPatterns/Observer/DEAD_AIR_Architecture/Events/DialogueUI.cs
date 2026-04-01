using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using DeadAir.Events;

namespace DeadAir.UI
{
    public class DialogueUI : MonoBehaviour
    {
        #region Serialized Fields
        // Serialized Fields
        [Header("Text Display")]
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private RectTransform _continueIndicator;

        // [Header("Colors")]
        // [SerializeField] private Color _narratorColor = Color.yellow;
        // [SerializeField] private Color _wardColor = Color.yellow;
        // [SerializeField] private Color _irisColor = Color.green;

        [Header("Typewriter")]
        [SerializeField] private float _typewriterSpeed = 0.03f;

        [Header("Choices")]
        [SerializeField] private Transform _choicesContainer;
        [SerializeField]
        // private ChoiceButton _choiceButtonPrefab;
        #endregion

        #region Private Fields
        private Coroutine _typewriterCoroutine;
        private bool _isTyping;
        private bool _skipRequested;
        // private List<ChoiceButton> _activeChoiceButtons = new List<ChoiceButton>();
        private bool _choicesVisible;
        #endregion

        #region Unity Lifecycle
        private void OnEnable()
        {
            // Subscribe a:
            // - OnDialogueLine
            // - OnSpeakerLine
            // - OnChoicesPresented
            // - OnUICommand
            // - OnStoryEnd
        }
        private void OnDisable()
        {
            // Unsubscribe da TUTTI
        }
        private void Update()
        {
            // Se click o space, chiama HandlePlayerInput()
        }
        #endregion

        #region Event Handlers
        private void HandleDialogueLine(string text) { }
        private void HandleSpeakerLine(string speaker, string text) { }
        private void HandleChoicesPresented(List<Choice> choices) { }
        private void HandleUICommand(string command) { }
        private void HandleStoryEnd() { }
        #endregion

        #region Metodi Typewriter
        private void ShowText(string text, Color color)
        {
            StopTypewriter();
            _dialogueText.color = color;
            _typewriterCoroutine = StartCoroutine(TypewriterEffect(text));
        }

        private IEnumerator TypewriterEffect(string text)
        {
            // Loop sui char
            // WaitForSeconds tra ogni char
            // Controllo _skipRequested
            yield break;
        }

        private void StopTypewriter()
        {
            if (_typewriterCoroutine != null)
                StopCoroutine(_typewriterCoroutine);
        }
        #endregion
    }
}


