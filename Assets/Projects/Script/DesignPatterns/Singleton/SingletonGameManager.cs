using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonGameManager : Singleton<SingletonGameManager>
{
    #region Implementing a Singleton
    public int Score { get; private set; }

    public void IncreaseScore (int amount)
    {
        Score += amount;
    }
    #endregion

    #region Setting the Singleton
    
    public override void Awake()
    {
        base.Awake();
        Score = 0;
        Debug.Log("GameManager inizializzato e pronto!");
    }
    #endregion
}

