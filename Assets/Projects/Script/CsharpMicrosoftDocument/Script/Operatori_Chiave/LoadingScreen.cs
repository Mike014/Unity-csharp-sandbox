using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen
{
    private GameObject _loadingScreen;
    private List<int> _assetList;

    IEnumerator ILoadingScreen()
    {
        // Mostra loading screen
        _loadingScreen.SetActive(true);
        yield return null;

        // Load assets
        // yield return StartCoroutine(LoadAssets());

        // Initialize game
        // yield return StartCoroutine(InitializeGame());

        // Wait 1 second per far vedere il loading completo
        // yield return new WaitForSeconds(1f);

        // Nascondi loading screen
        _loadingScreen.SetActive(false);

        // Start Game
        StartGame();
    }

    IEnumerator LoadAssets()
    {
        for (int i = 0; i < _assetList.Count; i++)
        {
            
        }

        yield return null;
    }

    void StartGame()
    {
        // 
    }
}