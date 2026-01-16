using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Offset (distanza) desiderato rispetto al player
    // (X=0 centrato, Y=1.2 alti, Z=-2.6 indietro)
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    // Riferimento al Transform del Player
    private Transform _target;


    void Start()
    {   
        // Trova il player nella scena e salva il riferimento
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // Calcola la posizione nel mondo basata sull'offset locale del target
        this.transform.position = _target.TransformPoint(camOffset);

        // Ruota la camera per guardare il target
        this.transform.LookAt(_target);
    }
}
