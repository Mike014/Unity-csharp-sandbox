using System.Threading;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private volatile bool _isLoading;
    private string _loadedData;

    void Start()
    {
        Thread loadThread = new Thread(LoadData);

    }

    void LoadData()
    {
        // ..
    }
}