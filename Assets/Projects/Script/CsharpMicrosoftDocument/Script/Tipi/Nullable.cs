using UnityEngine;

public class Nullable : MonoBehaviour
{
    int? playerScore = null; // Player non ha ancora score

    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SetScore(5);
            DisplayScore();
        }
        else
        {
            DisplayScore();
        }
    }

    void SetScore(int score)
    {
        playerScore = score;
    }

    void DisplayScore()
    {
        if(playerScore.HasValue)
        {
            Debug.Log($"Score: {playerScore}");
        }
        else
        {
            Debug.Log("No Score Yet");
        }
    }
}
