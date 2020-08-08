using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotateSpeed = 25f;
    private float horizontalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate( Vector3.up * Time.deltaTime * rotateSpeed * horizontalInput, Space.Self);
    }
}
