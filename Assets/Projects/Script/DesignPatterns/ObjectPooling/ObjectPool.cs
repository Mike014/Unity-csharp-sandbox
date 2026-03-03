using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _minimumAmount;

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _minimumAmount; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(_prefab);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = pool.Find (x => !x.activeSelf);

        if ( obj == null )
        {
            obj = CreateNewObject();
        }

        obj.SetActive(true);
        return obj;
    }
}

/*
This script will
manage our object pool, pre-instantiating a specified number of objects from a given prefab and
providing a way to retrieve and return objects from the pool.
*/