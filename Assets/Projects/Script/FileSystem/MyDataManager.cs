using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDataManager : MonoBehaviour
{
    private string _dataPath;

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";

        Debug.Log(_dataPath);
    }
}
