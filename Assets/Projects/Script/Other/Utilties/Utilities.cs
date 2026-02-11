using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per gestire i livelli

public static class Utilities
{
    // Variabile statica : condivisa da tutto il gioco
    public static int PlayerDeaths = 0;

    // Metodo statico : può essere chiamato ovunque senza "istanza"
    public static void RestartLevel()
    {
        // Carica la scena all'inidice 0 (solitamente la prima scena)
        SceneManager.LoadScene(0);

        // Ripristina il tempo di gioco (importante se era in pausa)
        Time.timeScale = 1.0f;
    }

    // Overload con parametro int e ritorno bool
    public static bool RestartLevel(int sceneIndex)
    {
        // PlayerDeaths è 0
        Debug.Log("Player deaths: " + PlayerDeaths);

        // Chiamiamo il metodo usando la parola chiave "ref"
        string message = UpdateDeathCount(out PlayerDeaths);

        // PlayerDeaths diventa 1
        Debug.Log("Player Deaths: " + PlayerDeaths);
        Debug.Log(message);

        // Carichiamo la scena basandoci sull'indice passato, non più su un numero fisso
        SceneManager.LoadScene(sceneIndex);

        // Resettiamo il tempo di gioco 
        Time.timeScale = 1.0f;

        // Restituiamo true per confermare che l'operazione è avvenuta
        return true;
    }

    // ref version
    /*
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;

        return "Next time you'll be at number " + countReference;
    }
    */

    // out version
    public static string UpdateDeathCount(out int countReference)
    {
        // Dobbiamo assegnare un valore prima di fare qualsiasi operazione o uscire
        countReference = 1;

        return "Next time you'll be at number " + countReference;
    }
    
}

