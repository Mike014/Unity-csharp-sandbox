using UnityEngine;

public class outExample : MonoBehaviour
{
    string levelName;
    int enemyCount;

    void GetLevelData(out string name, out int count)
    {
        // Il metodo DEVE assegnare i valori
        name = "Foresta Oscura";
        count = 15;
    }

    void Start()
    {
        GetLevelData(out levelName, out enemyCount);
    }
}