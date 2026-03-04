using UnityEngine;

public class SingletonGameBehaviour : Singleton<SingletonGameBehaviour>
{
    private PlayerBehaviour _player;

    // OnEnable: posto corretto per iscriversi
    // Esegue solo quando l'oggetto è attivo, non al semplice caricamento
    void Start()
    {
        Debug.Log("SingletonGameBehaviour Start gira");

        _player = FindAnyObjectByType<PlayerBehaviour>();

        Debug.Log($"_player trovato: {_player}"); // null o il riferimento

        if (_player == null)
        {
            Debug.LogWarning("Player Behaviour non trovato!");
            return;
        }

        _player.OnPlayerJump += HandleJump;
        Debug.Log("Iscritto all'evento");
    }

    private void OnDisable()
    {
        if (_player == null) return;

        _player.OnPlayerJump -= HandleJump;
        Debug.Log("Disiscritto dall'evento");
    }

    private void HandleJump()
    {
        Debug.Log("Il player ha saltato.");
    }
}

/*
[PlayerBehavior] dichiara delegate + event
       ↓
[GameBehavior] si iscrive con +=
       ↓
[PlayerBehavior] chiama Invoke() → tutti i subscriber ricevono
*/