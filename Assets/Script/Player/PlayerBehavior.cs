using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // 1. Variabili pubbliche per configurare la velocità dall'Inspector
    public float moveSpeed = 5f;
    public float rotateSpeed = 75f;

    // 2. Variabili private per memorizzare l'input del giocatore
    private float _vInput;
    private float _hInput;

    void Update()
    {
        // Rileva input W/S o Frecce Su/Giù
        _vInput = Input.GetAxis("Vertical") * moveSpeed;

        // Rileva input A/D o Frecce Sinistra/Destra
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // Muove la capsula avanti/indietro
        this.transform.Translate(Vector3.forward *_vInput * Time.deltaTime);
       
        // Ruota la capsula attorno all'asse Y (su se stessa)
        this.transform.Rotate(Vector3.up *_hInput * Time.deltaTime);
    }
}
