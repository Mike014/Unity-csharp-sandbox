using System.Collections;
using UnityEngine;

public class Iteration : MonoBehaviour
{
    [SerializeField] private int _target = 5;

    void Start()
    {
        StartCoroutine(ForwardIteration());
        StartCoroutine(BackwardIteration());
        StartCoroutine(NestedFor());
        StartCoroutine(CreateGrid());
    }

    IEnumerator ForwardIteration()
    {
        for (int i = 0; i < _target; i++)
        {
            Debug.Log(i);
        }

        yield return new WaitForSeconds(.5f);
    }

    IEnumerator BackwardIteration()
    {
        for (int i = _target - 1; i >= 0; i--)
        {
            Debug.Log(i);
        }

        yield return new WaitForSeconds(.5f);
    }

    IEnumerator NestedFor()
    {
        for (int i = 0; i < _target; i++)
        {
            for (int j = 0; j <= 10; j++)
            {
                Debug.Log($"{i * j}\t");
            }
        }

        yield return new WaitForSeconds(.5f);
    }

    IEnumerator CreateGrid()
    {
        int[,] grid = new int[5, 5];

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                grid[x, y] = x + y;
            }
        }
        yield return new WaitForSeconds(.5f);
    }
}
