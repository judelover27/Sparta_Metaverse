using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

        Vector3 pos = transform.position;
        transform.position = pos;
    }
}

