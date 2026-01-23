using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBasic : MonoBehaviour
{

    public float rotationSpeed = 10f;
    Transform itemTransform; 

    void Start()
    {
        itemTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        itemTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }

}
