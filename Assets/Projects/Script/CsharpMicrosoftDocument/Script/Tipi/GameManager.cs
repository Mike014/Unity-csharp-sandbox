using System;
using UnityEngine;

namespace GameManager
{
    public enum GameState
    {
        None = 0,
        MainMenu = 1,
        Playing = 2,
        Paused = 3,
        GameOver = 4
    }
    
    public class GameManager : MonoBehaviour
    {
        private GameState _currentState = GameState.None; // Inizializzazione esplicita

        public void ChangeState(GameState newState)
        {
            if (!Enum.IsDefined(typeof(GameState), newState))
            {
                Debug.LogError($"Invalid Game State: {newState}");
                return;
            }

            _currentState = newState;
        }
    }
}


