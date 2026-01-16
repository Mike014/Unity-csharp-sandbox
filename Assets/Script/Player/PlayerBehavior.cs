using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Variabili pubbliche per configurare la velocità dall'Inspector
    public float moveSpeed = 5f;
    public float rotateSpeed = 75f;

    // Variabili private per memorizzare l'input del giocatore
    private float _vInput;
    private float _hInput;

    // Variabile per conservare il riferimento al RigidBody
    private Rigidbody _rb;

    void Start()
    {
        // Recuperiamo il componente Rigidbody collegato a questo oggetto
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rileva input W/S o Frecce Su/Giù
        _vInput = Input.GetAxis("Vertical") * moveSpeed;

        // Rileva input A/D o Frecce Sinistra/Destra    
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // PRIMA VERSIONE DI MOVIMENTO PLAYER CON TRANSFORM
        // // Muove la capsula avanti/indietro
        // this.transform.Translate(Vector3.forward *_vInput * Time.deltaTime);
        // // Ruota la capsula attorno all'asse Y (su se stessa)
        // this.transform.Rotate(Vector3.up *_hInput * Time.deltaTime);
    }

    // La fisicia deve sempre stare in FixedUpdate
    void FixedUpdate()
    {
        // Calcola la rotazione
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // Applicazione del movimento fisico
        // Spostiamo il Rigidbody alla posizione attuale + il passo in avanti calcolato
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        // Applicazione della rotazione fisica
        _rb.MoveRotation(_rb.rotation * angleRot);

        /*
        In Update usavamo Time.deltaTime. 
        In FixedUpdate dobbiamo usare Time.fixedDeltaTime. È l'intervallo di tempo costante tra un calcolo fisico e l'altro. 
        Garantisce che la velocità di gioco sia identica su tutti i computer.
        */
    }
}
