using UnityEngine;

// COSA FA: Forza la struct a essere di sola lettura.
// PERCHÉ È SCRITTO COSÌ: 'readonly' garantisce al compilatore che questa struct non cambierà 
// mai dopo la sua creazione. Questo previene bug logici e permette al compilatore 
// di ottimizzare aggressivamente la memoria.
public readonly struct PlayerStatsGood
{
    public readonly int Score;
    public readonly float Health;

    public PlayerStatsGood(int score, float health)
    {
        Score = score;
        Health = health;
    }
}

public class NewPlayerStats : MonoBehaviour
{
    private PlayerStatsGood _goodStats;

    void Start()
    {
        _goodStats = new PlayerStatsGood(10, 100f);
    }

    void Update()
    {
        Debug.Log($"Punteggio: {_goodStats.Score.ToString()}");
    }

// PERCHÉ USA 'in': Il modificatore 'in' è come 'ref', ma dice al compilatore
// "ti passo l'originale per risparmiare memoria, ma ti vieto di modificarlo".
    private void ProcessStatsGood(in PlayerStatsGood stats)
    {
        if (stats.Health <= 0)
        {
            // logica di morte
            Debug.Log("You are DEAD!!");
        }
    }
}
