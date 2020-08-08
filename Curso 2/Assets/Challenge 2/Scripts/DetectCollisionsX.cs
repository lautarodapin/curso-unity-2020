using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
