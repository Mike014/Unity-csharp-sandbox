using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public string ShowPrompt(string prompt)
    {
        return prompt;
    }

    public void HidePrompt()
    {

    }
}

    