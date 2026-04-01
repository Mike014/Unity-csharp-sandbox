using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DeadAir.UI
{
    [RequireComponent(typeof(Button))]
    public class ChoiceButton : MonoBehaviour
    {
        // Serialized Fields
        [SerializeField] private TextMeshProUGUI _choiceText;
        [SerializeField] private Button _button;

        // Private Fields
        private int _choiceIndex;
        private Action<int> _onClickCallback;

        // Unity Lifecycle
        private void OnEnable()
        {
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleClick);
        }

        // Public API
        public void Setup(int index, string text, Action<int> onClick)
        {
            _choiceIndex = index;
            _onClickCallback = onClick;
            _choiceText.text = "> " + text; 
        }

        // Private Methods
        private void HandleClick()
        {
            _onClickCallback?.Invoke(_choiceIndex);
        }
    }
}


