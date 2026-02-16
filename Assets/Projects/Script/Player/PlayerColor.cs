using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // StartCoroutine
            StartCoroutine(ChangeColorSequence());
        }
    }

    private IEnumerator ChangeColorSequence()
    {
        Debug.Log("Inizio il timer...");

        yield return StartCoroutine(TimerManager.Instance.StartCountdown(3));

        Debug.Log("Timer finito! Cambio colore.");
        ChangeColor();
    }

    private void ChangeColor()
    {
        _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}


